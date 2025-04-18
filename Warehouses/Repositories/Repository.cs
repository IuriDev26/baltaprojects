using Microsoft.EntityFrameworkCore;
using Warehouses.Data;
using Warehouses.Models;

namespace Warehouses.Repositories;

public class Repository<T> where T : BaseEntity
{
    private readonly WarehouseDataContext _context;
    
    public Repository(WarehouseDataContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync(int skip = 0, int take = 25)
    {
        
        var entities = await _context
            .Set<T>()
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        
        return entities;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var entity = await _context
            .Set<T>()
            .FirstOrDefaultAsync( x => x.Id == id );
        
        if (entity == null)
            throw new KeyNotFoundException();
        
        return entity;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
    
}