using Application.DTOs;
using Application.Interfaces;
using FluentResults;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
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
