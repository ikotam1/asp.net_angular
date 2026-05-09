using Application.Common.Errors;
using Application.Common.Extensions;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Services;
using FluentResults;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<UserDto>> GetCurrentUser(Guid userId)
    {
        var user = await _repository.GetByIdAsync(userId);

        if (user != null)
        {
            return Result.Ok(new UserDto
            {
                Name = user.Name,
                Email = user.Email
            });
        }
        
        return Result.Fail(UserErrors.UserNotFound.ToError());
    }

    public async Task<Result<List<UserDto>>> GetUsers()
    {
        var users = await _repository.GetAllAsync();

        return Result.Ok(users.Select(u => new UserDto
        {
            Name = u.Name,
            Email = u.Email
        }).ToList());
    }
}
