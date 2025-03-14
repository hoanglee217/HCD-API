using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.BlogCategory;

using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogCategory;

public class GetAllBlogCategoriesRequestHandler(BlogCategoryService BlogCategoryService) : IRequestHandler<GetAllBlogCategoriesRequest, GetAllBlogCategoriesResponse>
{
    public Task<GetAllBlogCategoriesResponse> Handle(GetAllBlogCategoriesRequest request, CancellationToken cancellationToken)
    {
        return BlogCategoryService.GetAllBlogCategory(request);
    }
}