using System.Linq.Expressions;
using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Abstractions;

namespace Hcd.Common.Base;

public abstract class BaseDomainService<TEntity, TKey>(IRepository<TEntity, TKey> mainRepository): IBaseDomainService<TEntity> where TEntity: class
{
    public string GetCacheKey(string key)
    {
        return $"{typeof(TEntity).Name}_{key}";
    }
    
    public IQueryable<TEntity> Search(string? searchTerm)
    {
        return mainRepository.Search(searchTerm);
    }

    
    public IQueryable<TEntity> GetAll()
    {
        return mainRepository.GetAll();
    }
    
    public IQueryable<TEntity> GetAll(string? search, string? filter)
    {
        var data = this.Search(search);
        return data;
    }

    public async Task<TEntity?> FindAsync(TKey id)
    {
        return await mainRepository.FindAsync(id);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await mainRepository.FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        return await mainRepository.AddAsync(entity);
    }
    
    public async Task AddRangeAsync(List<TEntity> entities)
    {
        await mainRepository.AddRangeAsync(entities);
    }
    
    public void AddRange(List<TEntity> entities)
    {
        mainRepository.AddRange(entities);
    }
    
    public async Task<TEntity> Update(TEntity entity)
    {
        return await mainRepository.Update(entity);
    }
    public void UpdateRange(List<TEntity> entities)
    {
        mainRepository.UpdateRange(entities);
    }

    public void DeleteRange(List<TEntity> entities)
    {
        mainRepository.RemoveRange(entities);
    }

    public TEntity Delete(TKey id)
    {
        return mainRepository.Remove(id);
    }
}