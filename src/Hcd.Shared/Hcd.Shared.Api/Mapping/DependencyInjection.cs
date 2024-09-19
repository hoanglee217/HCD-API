using Mapster;
using MapsterMapper;
using System.Reflection;
using Hcd.Shared.Common.Enums;
using Microsoft.Extensions.DependencyInjection;
using Hcd.Identity.Data.Entities.Authentication;
using Hcd.Identity.Contracts.Requests.Authentication;

namespace Hcd.Shared.Api.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.NewConfig<RegisterRequest, User>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Role, src => UserRoleEnums.Guest);
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
            return services;
        }
    }
}