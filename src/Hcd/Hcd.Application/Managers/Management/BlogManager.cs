using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Management;

namespace Hcd.Application.Managers.Management
{
    public class BlogManager(IManagementRepository<Blog> blogRepository)
    : ManagementDomainService<Blog>(blogRepository);
}