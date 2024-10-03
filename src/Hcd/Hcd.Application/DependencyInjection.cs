using Hcd.Application.Services.Authentication;
using Hcd.Common.Interface.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Hcd.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}