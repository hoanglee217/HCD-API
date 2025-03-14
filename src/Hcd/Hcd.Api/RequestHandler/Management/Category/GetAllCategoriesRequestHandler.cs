using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Category;

public class GetAllCategoriesRequestHandler(CategoryService categoryService) : IRequestHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
{
    public Task<GetAllCategoriesResponse> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        return categoryService.GetAllCategories(request);
    }
}