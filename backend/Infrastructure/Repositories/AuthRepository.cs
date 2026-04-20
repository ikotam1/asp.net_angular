using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthRepository : CommonRepository<User>, IAuthRepository
{
    public AuthRepository(AppDbContext context) : base(context)
    {
    }

    public async Task Register(User user)
    {
        await AddAsync(user);
    }
}
