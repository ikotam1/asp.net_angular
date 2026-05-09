using Domain.Entities;

namespace Application.Interfaces.InfraServices;

public interface ITokenService
{
    /// <summary>
    /// Generates a JWT access token for the given user.
    /// </summary>
    /// <param name="user">user</param>
    /// <returns>access token</returns>
    string GenerateAccessToken(User user);

    /// <summary>
    /// Generates a secure random refresh token for the given user.
    /// </summary>
    /// <param name="user">user</param>
    /// <returns>refresh token</returns>
    string GenerateRefreshToken(User user);

    /// <summary>
    /// Validate refresh token
    /// </summary>
    /// <param name="token">token</param>
    /// <returns></returns>
    bool ValidateRefreshToken(RefreshToken? token);
}
