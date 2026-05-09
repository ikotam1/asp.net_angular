using Application.DTOs.Request;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IAuthService
{
    Task<Result> Register(RegisterRequest dto);

    Task<string?> Login(LoginRequest dto);
}
