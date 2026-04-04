using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        // TODO: NO TRACKING
        return await _context.Users.ToListAsync();
    }

    public async Task Add(User user)
    {
        // TODO: AUTO MAPPER DTO -> ENTITY
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
