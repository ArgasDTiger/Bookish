using Core.Entities;
using CSharpVitamins;

namespace Core.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(ShortGuid id);
    Task<bool> DeleteAsync(ShortGuid id);
    Task AddAsync(TEntity item);
    Task Update(TEntity item);
    Task<bool> SaveAsync();
}