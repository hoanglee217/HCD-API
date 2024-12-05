using System.Reflection;
using System.Text;
using Hcd.Application.Common.Interfaces.Authentication;
using Hcd.Application.Common.Interfaces.Services;
using Hcd.Common;
using Hcd.Common.Requests.Authentication;
using Hcd.Common.Enums;
using Hcd.Data.Entities.Authentication;
using Hcd.Infrastructure.Authentication;
using Hcd.Infrastructure.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Hcd.Common.Exceptions;

namespace Hcd.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IPasswordHandler, PasswordHandler>();

            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = EnvGlobal.JwtIssuer,
                    ValidAudience = EnvGlobal.JwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EnvGlobal.JwtAccessSecret!)),
                    ClockSkew = TimeSpan.Zero
                };
                // Optional: Handle token validation failures (e.g., logging, custom response)
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception is SecurityTokenExpiredException)
                        {
                            // Token has expired
                            throw new GoneException($"Need to refresh token");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }
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