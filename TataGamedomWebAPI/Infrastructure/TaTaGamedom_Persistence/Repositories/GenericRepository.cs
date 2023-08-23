using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.Common;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _dbContext;

    public GenericRepository(AppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task CreateAsync(IEnumerable<T> entities)
    {
        await _dbContext.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetListAsync()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

	public async Task DeleteAsync(T entity)
	{
		_dbContext.Remove(entity);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(IEnumerable<T> entities)
	{
		_dbContext.RemoveRange(entities);
		await _dbContext.SaveChangesAsync();
	}
}
