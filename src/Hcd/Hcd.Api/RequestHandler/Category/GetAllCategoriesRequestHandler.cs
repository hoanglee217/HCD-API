using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class GetAllCategoriesRequestHandler(ICategoryService categoryService) : IRequestHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
{
    private readonly ICategoryService _categoryService = categoryService;
    public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetAllCategories(request, cancellationToken);
    }
}