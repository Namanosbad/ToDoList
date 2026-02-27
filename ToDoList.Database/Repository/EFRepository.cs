using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Database.Repository;

public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly ToDoListDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public EFRepository(ToDoListDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            return;
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id) => await _dbSet.AnyAsync(entity => entity.Id == id);
}
