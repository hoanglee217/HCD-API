using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class DeleteCategoryRequestHandler(CategoryService categoryService) : IRequestHandler<DeleteCategoryRequest>
{
    public Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        return categoryService.DeleteCategory(request);
    }
}