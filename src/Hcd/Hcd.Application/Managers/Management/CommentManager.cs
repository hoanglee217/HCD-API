using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Management;

namespace Hcd.Application.Managers.Management
{
    public class CommentManager(IManagementRepository<Comment> commentRepository)
    : ManagementDomainService<Comment>(commentRepository);
}