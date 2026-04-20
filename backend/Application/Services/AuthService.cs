using System.Text;
using Application.DTOs.Request;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Interfaces.Response;
using Application.DTOs.Response;

namespace Application.Services;

public partial class AuthService
{
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IAuthRepository repository, IUserRepository userRepository, IConfiguration config)
    {
        _userRepository = userRepository;
        _configuration = config;
        _passwordHasher = new();
    }

    public async Task<IResult> Register(RegisterRequest dto)
    {
        // Check if user with email already exists
        var existingUser = await _userRepository.GetByEmail(dto.Email);
        if (existingUser != null)
            return ResultCreator.Failure("User with this email already exists");

        //  TODO: USE AUTO MAPPER
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email
        };

        user.PasswordHashed = _passwordHasher.HashPassword(user, dto.Password);

        await _userRepository.AddAsync(user);

        return ResultCreator.Success();
    }

    public async Task<string?> Login(LoginRequest dto)
    {
        var user = await _userRepository.GetByEmail(dto.Email);

        if (user == null)
            return null;

        var result = VerifyPassword(user, dto.Password);

        if (result == PasswordVerificationResult.Failed)
            return null;

        var token = GenerateJwtToken(user);

        // TODO: invalidate old tokens
        
        return token;
    }
}

public partial class AuthService
{
    private PasswordVerificationResult VerifyPassword(User user, string password)
        => _passwordHasher.VerifyHashedPassword(user, user.PasswordHashed, password);

    private string GenerateJwtToken(User user)
    {
        // TODO: GET KEY FROM CONFIG
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
        _ = int.TryParse(_configuration.GetSection("Jwt:Expired").Value, out var expired);      

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims:
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            ],
            expires: DateTime.Now.AddHours(expired),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
