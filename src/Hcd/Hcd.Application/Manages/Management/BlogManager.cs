using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Management;

namespace Hcd.Application.Manages.Management
{
    public class BlogManager(IManagementRepository<Blog> blogRepository)
    : ManagementDomainService<Blog>(blogRepository);
}