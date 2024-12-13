using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class CreateBlogRequestHandler(BlogService blogService) : IRequestHandler<CreateBlogRequest, CreateBlogResponse>
{
    public Task<CreateBlogResponse> Handle(CreateBlogRequest request, CancellationToken cancellationToken)
    {
        return blogService.CreateBlog(request);
    }
}