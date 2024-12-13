using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class UpdateCategoryRequestHandler(CategoryService categoryService) : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
{
    public Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        return categoryService.UpdateCategory(request);
    }
}