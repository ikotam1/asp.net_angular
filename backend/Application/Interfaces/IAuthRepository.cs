using Application.Interfaces.common;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthRepository : ICommonRepository<User>
{
    Task Register(User user);
}
