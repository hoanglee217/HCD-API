using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.System;

namespace Hcd.Application.Manages.System
{
    public class OptionManager(IManagementRepository<Option> OptionRepository)
    : ManagementDomainService<Option>(OptionRepository);
}