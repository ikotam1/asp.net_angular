using Domain.Entities;

namespace Application.Interfaces.InfraServices;

public interface IJWTService
{
    string GenerateAccessToken(User user);

    string GenerateRefreshToken(User user);
}
