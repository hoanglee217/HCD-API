using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Category;

public class DeleteCategoryRequestHandler(CategoryService categoryService) : IRequestHandler<DeleteCategoryRequest>
{
    public Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        return categoryService.DeleteCategory(request);
    }
}