using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class UpdateBlogRequestHandler(BlogService blogService) : IRequestHandler<UpdateBlogRequest, UpdateBlogResponse>
{
    public Task<UpdateBlogResponse> Handle(UpdateBlogRequest request, CancellationToken cancellationToken)
    {
        return blogService.UpdateBlog(request);
    }
}