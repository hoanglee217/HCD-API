using Hcd.Identity.Infrastructure;
using Hcd.Identity.Application;
using Hcd.Shared.Common.Exceptions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddInfrastructure();
    builder.Services.AddApplication();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseExceptionHandler(opt => { });
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}