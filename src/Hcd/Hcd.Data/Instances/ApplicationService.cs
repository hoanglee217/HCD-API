using MapsterMapper;
using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Abstractions;
using Hcd.Common.Interfaces.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Hcd.Application.Common.Interfaces.Services;

namespace Hcd.Data.Instances;
public abstract class ApplicationService : IApplicationService
{
    private readonly IServiceProvider _serviceProvider;

    protected ApplicationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected IMapper Mapper => _serviceProvider.GetRequiredService<IMapper>();
    protected IUnitOfWork UnitOfWork => _serviceProvider.GetRequiredService<IUnitOfWork>();
    protected ICurrentUserService CurrentUser => _serviceProvider.GetRequiredService<ICurrentUserService>();
    protected IJwtTokenGenerator JwtTokenGenerator => _serviceProvider.GetRequiredService<IJwtTokenGenerator>();
    protected IPasswordHandler PasswordHandler => _serviceProvider.GetRequiredService<IPasswordHandler>();
    protected IDateTimeProvider DateTimeProvider => _serviceProvider.GetRequiredService<IDateTimeProvider>();
    protected ISlugGenerator SlugGenerator => _serviceProvider.GetRequiredService<ISlugGenerator>();

    public TService GetService<TService>() where TService : class
    {
        return _serviceProvider.GetRequiredService<TService>();
    }
}
