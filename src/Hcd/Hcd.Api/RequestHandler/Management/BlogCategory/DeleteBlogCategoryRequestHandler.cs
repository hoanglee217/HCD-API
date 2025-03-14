using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.BlogCategory;

using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogCategory;

public class DeleteBlogCategoryRequestHandler(BlogCategoryService BlogCategoryService) : IRequestHandler<DeleteBlogCategoryRequest>
{
    public Task Handle(DeleteBlogCategoryRequest request, CancellationToken cancellationToken)
    {
        return BlogCategoryService.DeleteBlogCategory(request);
    }
}