using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IRefreshTokenRepository : ICommonRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenAsync(string token, bool asNoTracking = true);

    // TODO: remove when expired
}
