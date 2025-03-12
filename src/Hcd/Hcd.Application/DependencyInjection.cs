using System.Reflection;
using Hcd.Application.Manages.Authentication;
using Hcd.Application.Manages.Management;
using Hcd.Application.Services.Authentication;
using Hcd.Application.Services.Management;
using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Authentication;
using Hcd.Data.Entities.Management;
using Hcd.Data.Instances;
using Microsoft.Extensions.DependencyInjection;

namespace Hcd.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // services.AddScoped<ApplicationService>();
            // // Correct registration
            services.AddScoped<AuthenticationService>();
            services.AddScoped<BlogService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<CommentService>();
            services.AddScoped<TagService>();
            // services.AddScoped<BlogCategoryService>(); 


            services.AddScoped<AuthenticationManager>();
            services.AddScoped(typeof(IManagementRepository<User>), typeof(ManagementRepository<User>));
            services.AddScoped<BlogManager>();
            services.AddScoped(typeof(IManagementRepository<Blog>), typeof(ManagementRepository<Blog>));
            services.AddScoped<CategoryManager>();
            services.AddScoped(typeof(IManagementRepository<Category>), typeof(ManagementRepository<Category>));
            services.AddScoped<CommentManager>();
            services.AddScoped(typeof(IManagementRepository<Comment>), typeof(ManagementRepository<Comment>));
            services.AddScoped<TagManager>();
            services.AddScoped(typeof(IManagementRepository<Tag>), typeof(ManagementRepository<Tag>));

            return services;
        }
    }
}