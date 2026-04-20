using Domain.Entities.common;

namespace Application.Interfaces.common;

public interface ICommonRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);

    Task<List<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task DeleteAsync(T entity);
}
