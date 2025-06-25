﻿namespace ToDoList.Domain.Interfaces;
public interface IRepository<TEntity>
          where TEntity : class, IEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity); 
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
