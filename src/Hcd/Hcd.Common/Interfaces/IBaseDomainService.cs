namespace Hcd.Common.Interfaces;

public interface IBaseDomainService<TEntity> : IDomainService where TEntity: class
{
    string GetCacheKey(string key);
}