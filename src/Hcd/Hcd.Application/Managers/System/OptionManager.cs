using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.System;

namespace Hcd.Application.Managers.System
{
    public class OptionManager(IManagementRepository<Option> OptionRepository)
    : ManagementDomainService<Option>(OptionRepository);
}