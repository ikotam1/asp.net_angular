using Application.Interfaces;
using Domain.Entities.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

// TODO: Implement specification pattern if there're many business queries
// TODO: Implemet CQRS pattern if heavy read/write operations
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

    public async Task<List<T>> GetAllAsync(bool asNoTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id, bool asNoTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }
}