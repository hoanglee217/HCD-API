namespace Hcd.Common.Interfaces.Abstractions;

public interface IUnitOfWork: IDisposable
{
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
