using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Category;
using MediatR;

namespace Hcd.Api.RequestHandler.Category;

public class GetDetailCategoryRequestHandler(CategoryService blogService) : IRequestHandler<GetDetailCategoryRequest, GetDetailCategoryResponse>
{
    public Task<GetDetailCategoryResponse> Handle(GetDetailCategoryRequest request, CancellationToken cancellationToken)
    {
        return blogService.GetDetailCategory(request);
    }
}