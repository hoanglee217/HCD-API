using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class CreateBlogRequestHandler(IBlogService blogService) : IRequestHandler<CreateBlogRequest, CreateBlogResponse>
{
    public async Task<CreateBlogResponse> Handle(CreateBlogRequest request, CancellationToken cancellationToken)
    {
        return await blogService.CreateBlog(request, cancellationToken);
    }
}