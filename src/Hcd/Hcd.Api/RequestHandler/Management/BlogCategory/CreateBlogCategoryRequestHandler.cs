using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.BlogCategory;

using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogCategory;

public class CreateBlogCategoryRequestHandler(BlogCategoryService BlogCategoryService) : IRequestHandler<CreateBlogCategoryRequest, CreateBlogCategoryResponse>
{
    public Task<CreateBlogCategoryResponse> Handle(CreateBlogCategoryRequest request, CancellationToken cancellationToken)
    {
        return BlogCategoryService.CreateBlogCategory(request);
    }
}