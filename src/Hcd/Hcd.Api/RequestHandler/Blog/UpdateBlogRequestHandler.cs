using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class UpdateBlogRequestHandler(IBlogService blogService) : IRequestHandler<UpdateBlogRequest, UpdateBlogResponse>
{
    public async Task<UpdateBlogResponse> Handle(UpdateBlogRequest request, CancellationToken cancellationToken)
    {
        return await blogService.UpdateBlog(request, cancellationToken);
    }
}