using Hcd.Common.Base;
using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Authentication;

namespace Hcd.Application.Manages.Authentication;

public class AuthenticationManager(IManagementRepository<User> userRepository)
    : ManagementDomainService<User>(userRepository);