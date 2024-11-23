using System.Reflection;
using Hcd.Application;
using Hcd.Infrastructure;
using Hcd.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Hcd.Application.Common.Interfaces;
using Hcd.Application.Common.Services;
using Hcd.Data;
using Hcd.Common;
using Hcd.Common.Interfaces;
using Hcd.Application.Services;

var builder = WebApplication.CreateBuilder(args);
{
    EnvLoader.LoadEnv();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    //mapper
    builder.Services.AddMapping();
    //mediator
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    //error handler
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    //dependence
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(
            EnvGlobal.ConnectionString,
            ServerVersion.AutoDetect(EnvGlobal.ConnectionString)
    ));
    //controller
    builder.Services.AddControllers();

    // Enable CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowFrontend", policy =>
        {
            policy.WithOrigins("http://localhost:3000")  // Allow the React frontend
                .AllowAnyHeader()  // Allow all headers
                .AllowAnyMethod(); // Allow all HTTP methods (GET, POST, etc.)
        });
    });
}

var app = builder.Build();
{
    // Use CORS middleware
    app.UseCors("AllowFrontend");
    app.UseExceptionHandler(opt => { });
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}