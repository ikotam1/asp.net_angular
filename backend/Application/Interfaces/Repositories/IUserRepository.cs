using Domain.Entities;

namespace Application.Interfaces;

public interface IUserRepository : ICommonRepository<User>
{
    Task<User?> GetByEmail(string email);
}
