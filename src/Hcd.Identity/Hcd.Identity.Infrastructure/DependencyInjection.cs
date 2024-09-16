using Hcd.Identity.Application.Common.Interfaces.Authentication;
using Hcd.Identity.Application.Common.Interfaces.Authentication.Account;
using Hcd.Identity.Application.Common.Interfaces.Services;
using Hcd.Identity.Infrastructure.Authentication;
using Hcd.Identity.Infrastructure.Authentication.Account;
using Hcd.Identity.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hcd.Identity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}