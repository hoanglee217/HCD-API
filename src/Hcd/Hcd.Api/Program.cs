using Hcd.Data;
using Hcd.Common;
using Hcd.Application;
using System.Reflection;
using Hcd.Infrastructure;
using Hcd.Common.Interfaces;
using Hcd.Common.Exceptions;
using Hcd.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    EnvLoader.LoadEnv();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();
    // builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    //mapper
    builder.Services.AddMapping();
    //mediator
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    //error handler
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    //dependence
    builder.Services.AddApplicationServices();
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