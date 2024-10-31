using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class GetAllCategoriesRequestHandler(ICategoryService categoryService) : IRequestHandler<GetAllCategoriesRequest, List<GetAllCategoriesResponse>>
{
    public async Task<List<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        return await categoryService.GetAllCategories(request, cancellationToken);
    }
}