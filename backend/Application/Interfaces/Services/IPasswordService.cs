using Domain.Entities;

namespace Application.Interfaces.InfraServices;

public interface IPasswordService
{
    bool VerifyPassword(User user, string password);

    string HashPassword(User user, string password);
}
