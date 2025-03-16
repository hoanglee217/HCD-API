using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Management;

namespace Hcd.Application.Managers.Management
{
    public class BlogCategoryManager(IManagementRepository<BlogCategory> blogCategoryRepository)
    : ManagementDomainService<BlogCategory>(blogCategoryRepository);
}