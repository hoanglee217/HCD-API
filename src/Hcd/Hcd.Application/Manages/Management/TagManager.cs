using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Management.Blog;

namespace Hcd.Application.Manages.Management
{
    public class TagManager(IManagementRepository<Tag> tagRepository)
    : ManagementDomainService<Tag>(tagRepository);
}