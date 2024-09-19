using System.Reflection;
using Hcd.Shared.Api.Mapping;
using Hcd.Identity.Application;
using Hcd.Identity.Infrastructure;
using Hcd.Shared.Common.Exceptions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddMapping();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseExceptionHandler(opt => { });
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}