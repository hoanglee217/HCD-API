using System.Linq.Expressions;

namespace Hcd.Common.Interfaces.Abstractions;
public interface IRepository { }
public interface IRelationRepository { }
public interface IRepository<TEntity, in TKey> : IRepository where TEntity : class
{
    IQueryable<TEntity> Search(string? searchTerm);
    IQueryable<TEntity> GetAll();
    // IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity?> FindAsync(TKey id);
    IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> Update(TEntity entity);
    void UpdateRange(List<TEntity> entities);
    void AddRange(List<TEntity> entities);
    Task AddRangeAsync(List<TEntity> entities);
    TEntity Remove(TKey id);
    void RemoveRange(List<TEntity> entities);
}
public interface IRelationDbRepository<TEntity, in TKey> : IRelationRepository, IRepository<TEntity, TKey> where TEntity : class
{
}