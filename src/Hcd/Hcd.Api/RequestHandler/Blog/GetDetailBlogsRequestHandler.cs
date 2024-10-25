using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class GetDetailBlogsRequestHandler(IBlogService blogService) : IRequestHandler<GetDetailBlogsRequest, GetDetailBlogsResponse>
{
    private readonly IBlogService _blogService = blogService;
    public async Task<GetDetailBlogsResponse> Handle(GetDetailBlogsRequest request, CancellationToken cancellationToken)
    {
        return await _blogService.GetDetailBlog(request, cancellationToken);
    }
}