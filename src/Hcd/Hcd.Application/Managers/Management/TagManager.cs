using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Management;

namespace Hcd.Application.Managers.Management
{
    public class TagManager(IManagementRepository<Tag> tagRepository)
    : ManagementDomainService<Tag>(tagRepository);
}