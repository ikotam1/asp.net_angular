using Application.Interfaces.common;
using Domain.Entities;
using Domain.Entities.common;

namespace Application.Interfaces;

public interface IUserRepository : ICommonRepository<User>
{
    Task<User?> GetByEmail(string email);
}
