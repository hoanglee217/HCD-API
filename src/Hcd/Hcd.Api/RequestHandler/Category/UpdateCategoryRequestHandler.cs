using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class UpdateCategoryRequestHandler(ICategoryService categoryService) : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
{
    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        return await categoryService.UpdateCategory(request, cancellationToken);
    }
}