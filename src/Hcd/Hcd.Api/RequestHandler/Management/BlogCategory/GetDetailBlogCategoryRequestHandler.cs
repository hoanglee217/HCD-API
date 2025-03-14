using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.BlogCategory;

using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogCategory;

public class GetDetailBlogCategoryRequestHandler(BlogCategoryService BlogCategoryService) : IRequestHandler<GetDetailBlogCategoryRequest, GetDetailBlogCategoryResponse>
{
    public Task<GetDetailBlogCategoryResponse> Handle(GetDetailBlogCategoryRequest request, CancellationToken cancellationToken)
    {
        return BlogCategoryService.GetDetailBlogCategory(request);
    }
}