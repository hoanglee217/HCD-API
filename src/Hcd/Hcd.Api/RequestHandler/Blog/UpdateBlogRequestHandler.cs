using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class UpdateBlogRequestHandler(IBlogService blogService) : IRequestHandler<UpdateBlogRequest, UpdateBlogResponse>
{
    private readonly IBlogService _blogService = blogService;
    public async Task<UpdateBlogResponse> Handle(UpdateBlogRequest request, CancellationToken cancellationToken)
    {
        return await _blogService.UpdateBlog(request, cancellationToken);
    }
}