using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Blog;
using MediatR;

namespace Hcd.Api.RequestHandler.Blog;

public class GetAllBlogsRequestHandler(IBlogService blogService) : IRequestHandler<GetAllBlogsRequest, List<GetAllBlogsResponse>>
{
    public async Task<List<GetAllBlogsResponse>> Handle(GetAllBlogsRequest request, CancellationToken cancellationToken)
    {
        return await blogService.GetAllBlogs(request, cancellationToken);
    }
}