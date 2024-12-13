using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class GetDetailBlogsRequestHandler(BlogService blogService) : IRequestHandler<GetDetailBlogsRequest, GetDetailBlogsResponse>
{
    public Task<GetDetailBlogsResponse> Handle(GetDetailBlogsRequest request, CancellationToken cancellationToken)
    {
        return blogService.GetDetailBlog(request);
    }
}