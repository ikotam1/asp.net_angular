using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IPasswordService
{
    bool VerifyPassword(User user, string password);

    string HashPassword(User user, string password);
}
