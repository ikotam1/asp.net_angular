using Application.DTOs;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<Result<List<UserDto>>> GetUsers();

    Task<Result<UserDto>> GetCurrentUser(Guid userId);
}
