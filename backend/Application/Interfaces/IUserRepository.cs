using Domain.Entities;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAll();

    Task<User?> GetByEmail(string email);

    Task<User?> GetById(Guid id);
}
