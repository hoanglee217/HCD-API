using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class DeleteCategoryRequestHandler(ICategoryService categoryService) : IRequestHandler<DeleteCategoryRequest>
{
    public Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        return categoryService.DeleteCategory(request, cancellationToken);
    }
}