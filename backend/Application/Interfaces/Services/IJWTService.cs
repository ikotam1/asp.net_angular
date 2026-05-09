using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IJWTService
{
    string GenerateToken(User user, string jwtKey, int expired);
}
