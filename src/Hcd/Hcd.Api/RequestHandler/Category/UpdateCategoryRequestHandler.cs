using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class UpdateCategoryRequestHandler(ICategoryService categoryService) : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
{
    private readonly ICategoryService _categoryService = categoryService;
    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        return await _categoryService.UpdateCategory(request, cancellationToken);
    }
}