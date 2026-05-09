using Domain.Entities.Common;

namespace Application.Interfaces;

public interface ICommonRepository<T> where T : BaseEntity
{
    // TODO: add cancellation token to all methods
    Task<T?> GetByIdAsync(Guid id, bool asNoTracking = true);

    Task<List<T>> GetAllAsync(bool asNoTracking = true);

    Task AddAsync(T entity);

    Task DeleteAsync(T entity);
}
