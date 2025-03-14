using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.BlogCategory;

using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogCategory;

public class UpdateBlogCategoryRequestHandler(BlogCategoryService BlogCategoryService) : IRequestHandler<UpdateBlogCategoryRequest, UpdateBlogCategoryResponse>
{
    public Task<UpdateBlogCategoryResponse> Handle(UpdateBlogCategoryRequest request, CancellationToken cancellationToken)
    {
        return BlogCategoryService.UpdateBlogCategory(request);
    }
}