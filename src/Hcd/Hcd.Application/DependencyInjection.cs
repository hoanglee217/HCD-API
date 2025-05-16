using Hcd.Application.Managers.Authentication;
using Hcd.Application.Managers.Management;
using Hcd.Application.Managers.System;
using Hcd.Application.Services.Authentication;
using Hcd.Application.Services.Management;
using Hcd.Application.Services.System;
using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.Authentication;
using Hcd.Data.Entities.Management;
using Hcd.Data.Entities.System;
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
            services.AddScoped<AuthenticationManager>();
            services.AddScoped(typeof(IManagementRepository<User>), typeof(ManagementRepository<User>));

            services.AddScoped<BlogService>();
            services.AddScoped<BlogManager>();
            services.AddScoped(typeof(IManagementRepository<Blog>), typeof(ManagementRepository<Blog>));

            services.AddScoped<CategoryService>();
            services.AddScoped<CategoryManager>();
            services.AddScoped(typeof(IManagementRepository<Category>), typeof(ManagementRepository<Category>));

            services.AddScoped<CommentService>();
            services.AddScoped<CommentManager>();
            services.AddScoped(typeof(IManagementRepository<Comment>), typeof(ManagementRepository<Comment>));

            services.AddScoped<TagService>();
            services.AddScoped<TagManager>();
            services.AddScoped(typeof(IManagementRepository<Tag>), typeof(ManagementRepository<Tag>));

            services.AddScoped<BlogCategoryService>();
            services.AddScoped<BlogCategoryManager>();
            services.AddScoped(typeof(IManagementRepository<BlogCategory>), typeof(ManagementRepository<BlogCategory>));

            services.AddScoped<BlogTagService>();
            services.AddScoped<BlogTagManager>();
            services.AddScoped(typeof(IManagementRepository<BlogTag>), typeof(ManagementRepository<BlogTag>));
            
            services.AddScoped<ImageService>();
            services.AddScoped<ImageManager>();
            services.AddScoped(typeof(IManagementRepository<Image>), typeof(ManagementRepository<Image>));

            return services;
        }
    }
}