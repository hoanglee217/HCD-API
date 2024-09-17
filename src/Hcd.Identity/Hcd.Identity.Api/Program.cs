using Hcd.Identity.Infrastructure;
using System.Reflection;
using Hcd.Identity.Application;
using Hcd.Shared.Common.Exceptions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseExceptionHandler(opt => { });
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}