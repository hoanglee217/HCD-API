namespace Hcd.Common.Interfaces.Abstractions;

public interface IManagementRepository<TEntity>: IRelationDbRepository<TEntity, Guid> where TEntity : class
{
}
