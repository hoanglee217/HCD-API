using Mapster;
using Hcd.Common;
using System.Text;
using MapsterMapper;
using Hcd.Common.Enums;
using System.Reflection;
using Hcd.Data.Instances;
using Hcd.Common.Exceptions;
using Hcd.Common.Interfaces;
using Hcd.Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;
using Hcd.Data.Entities.Authentication;
using Hcd.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Hcd.Common.Requests.Authentication;
using Hcd.Common.Interfaces.Abstractions;
using Hcd.Common.Interfaces.Authentication;
using Hcd.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Hcd.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Hcd.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register ApplicationService and its dependencies
            services.AddTransient<IApplicationService, AuthenticationService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>(); // Replace with your actual UnitOfWork implementation
            services.AddScoped<ICurrentUserService, CurrentUserService>(); // Replace with your actual service
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>(); // Replace with your actual JWT token generator
            services.AddScoped<IPasswordHandler, PasswordHandler>(); // Replace with your actual password handler

            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
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