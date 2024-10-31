using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class GetDetailBlogsRequestHandler(IBlogService blogService) : IRequestHandler<GetDetailBlogsRequest, GetDetailBlogsResponse>
{
    public async Task<GetDetailBlogsResponse> Handle(GetDetailBlogsRequest request, CancellationToken cancellationToken)
    {
        return await blogService.GetDetailBlog(request, cancellationToken);
    }
}