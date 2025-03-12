using MediatR;

namespace Hcd.Data.Instances;

public class UnitOfWork(
    ApplicationDbContext context,
    IServiceProvider serviceProvider
    ) : UnitOfWorkBase<ApplicationDbContext>(context, serviceProvider)
{
}
