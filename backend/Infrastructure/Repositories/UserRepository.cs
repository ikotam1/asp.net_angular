using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : CommonRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
        //TODO: Refactor to avoid duplicate context
    }

    public async Task<User?> GetByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
}
