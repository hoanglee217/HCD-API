using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Management;

namespace Hcd.Application.Managers.Management;

public class BlogTagManager(IManagementRepository<BlogTag> blogTagRepository) 
    : ManagementDomainService<BlogTag>(blogTagRepository);