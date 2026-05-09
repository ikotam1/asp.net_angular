using Application.DTOs.Request;
using Application.Interfaces;
using Domain.Entities;
using FluentResults;
using Application.Common.Errors;
using Application.Common.Extensions;
using Application.Interfaces.Services;

namespace Application.Services;

public partial class AuthService(
    IUserRepository userRepository,
    IPasswordService passwordService,
    IJWTService jwtService)
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

    public async Task<string?> Login(LoginRequest dto)
    {
        var user = await _userRepository.GetByEmail(dto.Email);

        if (user == null)
            return null;

        var isVerified = _passwordService.VerifyPassword(user, dto.Password);

        if (!isVerified)
            return null;

        var token = _jwtService.GenerateToken(user, string.Empty, 0);

        // TODO: invalidate old tokens
        
        return token;
    }
}
