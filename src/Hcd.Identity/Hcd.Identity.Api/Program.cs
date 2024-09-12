using Hcd.Identity.Infrastructure;
using Hcd.Identity.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddInfrastructure();
    builder.Services.AddApplication();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}