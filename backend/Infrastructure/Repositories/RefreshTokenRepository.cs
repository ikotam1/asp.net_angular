using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RefreshTokenRepository : CommonRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token, bool asNoTracking = true)
    {
        IQueryable<RefreshToken> query = _context.RefreshTokens;

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.Include(rt => rt.User)
                          .FirstOrDefaultAsync(rt => rt.Token == token);
    }
}
