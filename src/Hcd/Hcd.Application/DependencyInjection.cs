using Hcd.Application.Services.Authentication;
using Hcd.Application.Services.Management;
using Hcd.Common.Interface.Authentication;
using Hcd.Common.Interfaces.Management;
using Microsoft.Extensions.DependencyInjection;

namespace Hcd.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ITagService, TagService>();
            return services;
        }
    }
}