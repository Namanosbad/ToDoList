using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Database.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ToDoListDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public EFRepository(ToDoListDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public DbSet<TEntity> Repositories => _context.Set<TEntity>();
        DbSet<TEntity> Entities { get; }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var tarefa = new Tarefa
            {
                Id = Guid.NewGuid()
            };
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
            if (entity is null) return;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }
    }
}
