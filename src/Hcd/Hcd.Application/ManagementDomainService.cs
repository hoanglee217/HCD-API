using Hcd.Common.Base;
using Hcd.Common.Interfaces.Abstractions;

namespace Hcd.Application;

public class ManagementDomainService<TEntity>(IManagementRepository<TEntity> mainRepository)
    : BaseDomainService<TEntity, Guid>(mainRepository) where TEntity : class;
