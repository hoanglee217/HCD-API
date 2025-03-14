using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Blog;

using MediatR;

namespace Hcd.Api.RequestHandler.Management.Blog;

public class GetAllBlogsRequestHandler(BlogService blogService) : IRequestHandler<GetAllBlogsRequest, GetAllBlogsResponse>
{
    public Task<GetAllBlogsResponse> Handle(GetAllBlogsRequest request, CancellationToken cancellationToken)
    {
        return blogService.GetAllBlogs(request);
    }
}