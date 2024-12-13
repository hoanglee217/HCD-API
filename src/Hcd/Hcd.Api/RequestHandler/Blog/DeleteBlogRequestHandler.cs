using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class DeleteBlogRequestHandler(BlogService blogService) : IRequestHandler<DeleteBlogRequest>
{
    public Task Handle(DeleteBlogRequest request, CancellationToken cancellationToken)
    {
        return blogService.DeleteBlog(request);
    }
}