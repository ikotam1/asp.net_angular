using Application.Interfaces.common;
using Domain.Entities.common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public CommonRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // TODO: Refactor save changes one time after multiple operations
    public Task AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        return _context.SaveChangesAsync();
    }

    // TODO: Implement soft delete after adding IsDeleted property to BaseEntity
    // TODO: Refactor save changes one time after multiple operations
    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    }
}
