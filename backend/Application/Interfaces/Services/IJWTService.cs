using Domain.Entities;

namespace Application.Interfaces.InfraServices;

public interface IJWTService
{
    string GenerateToken(User user);
}
