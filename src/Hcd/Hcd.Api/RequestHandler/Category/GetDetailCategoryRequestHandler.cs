using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class GetDetailCategoryRequestHandler(ICategoryService blogService) : IRequestHandler<GetDetailCategoryRequest, GetDetailCategoryResponse>
{
    public async Task<GetDetailCategoryResponse> Handle(GetDetailCategoryRequest request, CancellationToken cancellationToken)
    {
        return await blogService.GetDetailCategory(request, cancellationToken);
    }
}