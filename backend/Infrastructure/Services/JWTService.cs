using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class JWTService : IJWTService
{
    public string GenerateToken(User user, string jwtKey, int expired)
    {
        // TODO: GET KEY FROM CONFIG
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims:
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            ],
            expires: DateTime.Now.AddHours(expired),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
