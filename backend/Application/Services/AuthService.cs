using Application.DTOs.Request;
using Application.Interfaces;
using Domain.Entities;
using FluentResults;
using Application.Common.Errors;
using Application.Common.Extensions;
using Application.Interfaces.Services;
using Application.Interfaces.InfraServices;
using Application.DTOs.Response;
using Application.Common.Caching;
using Application.Interfaces.Repositories;

namespace Application.Services;

public partial class AuthService(
    IUserRepository userRepository,
    IPasswordService passwordService,
    ITokenService tokenService,
    ICacheService cacheService,
    IRefreshTokenRepository refreshTokenRepository) : IAuthService
{
    private readonly IPasswordService _passwordService = passwordService;

    private readonly ITokenService _tokenService = tokenService;

    private readonly IUserRepository _userRepository = userRepository;

    private readonly ICacheService _cacheService = cacheService;

    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result> Register(RegisterRequest dto)
    {
        // Check if user with email already exists
        var existingUser = await _userRepository.GetByEmail(dto.Email);
        if (existingUser != null)
            return Result.Fail(UserErrors.EmailAlreadyExists.ToError());

        //  TODO: USE AUTO MAPPER
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email
        };

        user.PasswordHashed = _passwordService.HashPassword(user, dto.Password);

        await _userRepository.AddAsync(user);

        return Result.Ok();
    }

    public async Task<Result<LoginResponse>> Login(LoginRequest dto)
    {
        var user = await _userRepository.GetByEmail(dto.Email);

        if (user != null)
        {
            var isVerified = _passwordService.VerifyPassword(user, dto.Password);

            if (isVerified)
            {
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken(user);

                var refreshTokenInfo = new RefreshToken
                {
                    UserId = user.Id,
                    Token = refreshToken,
                    ExpiresAt = DateTime.UtcNow.AddDays(10) // TODO: make it configurable
                };

                await _refreshTokenRepository.AddAsync(refreshTokenInfo);

                await _cacheService.SetAsync(
                    CacheKeys.RefreshToken(refreshToken),
                    refreshTokenInfo,
                    new CacheOption
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(10), // TODO: make it configurable
                        SlidingExpiration = TimeSpan.FromDays(5) // TODO: make it configurable
                    }
                );

                return Result.Ok(new LoginResponse { AccessToken = accessToken, RefreshToken = refreshToken });
            }
        }
        
        return Result.Fail(UserErrors.InvalidCredentials.ToError());
    }

    public async Task<Result<LoginResponse>> RefreshToken(string refreshKey)
    {
        var refreshToken = await _cacheService.GetAsync<RefreshToken>(CacheKeys.RefreshToken(refreshKey));
        if (refreshToken == null)
        {
            refreshToken = await _refreshTokenRepository.GetByTokenAsync(refreshKey);
        }

        if (_tokenService.ValidateRefreshToken(refreshToken))
        {
            if (refreshToken?.User != null)
            {
                var newAccessToken = _tokenService.GenerateAccessToken(refreshToken.User);

                return Result.Ok(new LoginResponse
                {
                    AccessToken = newAccessToken,
                });
            }
        }

        return Result.Fail("Invalid refresh token");
    }
}