using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Category;

public class GetDetailCategoryRequestHandler(CategoryService blogService) : IRequestHandler<GetDetailCategoryRequest, GetDetailCategoryResponse>
{
    public Task<GetDetailCategoryResponse> Handle(GetDetailCategoryRequest request, CancellationToken cancellationToken)
    {
        return blogService.GetDetailCategory(request);
    }
}