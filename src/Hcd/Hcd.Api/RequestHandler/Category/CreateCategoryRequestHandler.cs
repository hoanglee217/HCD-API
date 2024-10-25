using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class CreateCategoryRequestHandler(ICategoryService categoryService) : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    private readonly ICategoryService _categoryService = categoryService;
    public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        return await _categoryService.CreateCategory(request, cancellationToken);
    }
}