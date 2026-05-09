using Application.DTOs.Request;
using Application.Interfaces;
using Domain.Entities;
using FluentResults;
using Application.Common.Errors;
using Application.Common.Extensions;
using Application.Interfaces.Services;
using Application.Interfaces.InfraServices;
using Application.DTOs.Response;

namespace Application.Services;

public partial class AuthService(
    IUserRepository userRepository,
    IPasswordService passwordService,
    IJWTService jwtService) : IAuthService
{
    private readonly IPasswordService _passwordService = passwordService;

    private readonly IJWTService _jwtService = jwtService;

    private readonly IUserRepository _userRepository = userRepository;

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
                var accessToken = _jwtService.GenerateAccessToken(user);
                var refreshToken = _jwtService.GenerateRefreshToken(user);
                return Result.Ok(new LoginResponse { AccessToken = accessToken, RefreshToken = refreshToken });
            }
        }
        
        return Result.Fail(UserErrors.InvalidCredentials.ToError());
    }
}
