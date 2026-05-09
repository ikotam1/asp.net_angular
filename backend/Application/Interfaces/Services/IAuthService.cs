using Application.DTOs.Request;
using Application.DTOs.Response;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IAuthService
{
    Task<Result> Register(RegisterRequest dto);

    Task<Result<LoginResponse>> Login(LoginRequest dto);
}
