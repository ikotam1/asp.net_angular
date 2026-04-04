using System;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

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
        var users = await _repository.GetAll();

        return users.Select(u => new UserDto
        {
            Name = u.Name,
            Email = u.Email
        }).ToList();
    }

    public async Task CreateUser(UserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email
        };

        await _repository.Add(user);
    }
}
