using Application.DTOs;
using Application.Interfaces;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserDto>> GetUsers()
    {
        var users = await _repository.GetAllAsync();

        return users.Select(u => new UserDto
        {
            Name = u.Name,
            Email = u.Email
        }).ToList();
    }
}
