using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Category;

public class UpdateCategoryRequestHandler(CategoryService categoryService) : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
{
    public Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        return categoryService.UpdateCategory(request);
    }
}