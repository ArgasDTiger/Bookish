using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetListOfAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task AddAsync(TEntity item);
    Task Update(TEntity item);
    Task<bool> SaveAsync();
    Task<TEntity?> GetEntityWithSpec(ISpecification<TEntity> spec);
    Task<List<TEntity?>> GetListAsync(ISpecification<TEntity> spec);
}