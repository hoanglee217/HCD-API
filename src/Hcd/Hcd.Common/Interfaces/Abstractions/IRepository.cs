using System.Linq.Expressions;

namespace Hcd.Common.Interfaces.Abstractions;
public interface IRepository {}
public interface IRelationRepository {}
public interface IRepository<TEntity, in TKey> : IRepository where TEntity : class
{
    IQueryable<TEntity> Search(string? searchTerm);
    IQueryable<TEntity> GetAll();
    // IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    Task AddRangeAsync(List<TEntity> entities);
    void UpdateRange(List<TEntity> entities);
    void AddRange(List<TEntity> entities);
    void RemoveRange(List<TEntity> entities);
    Task<TEntity?> FindAsync(TKey id);
    TEntity Remove(TKey id);
}
public interface IRelationDbRepository<TEntity, in TKey> : IRelationRepository, IRepository<TEntity, TKey> where TEntity : class
{
}