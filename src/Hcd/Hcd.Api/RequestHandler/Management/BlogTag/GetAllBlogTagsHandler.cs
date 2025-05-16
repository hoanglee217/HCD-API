using Hcd.Common.Requests.Management.BlogTag;
using Hcd.Application.Services.Management;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogTag;

public class GetAllBlogTagsHandler(BlogTagService blogTagService) : IRequestHandler<GetAllBlogTagsRequest, GetAllBlogTagsResponse>
{
    public Task<GetAllBlogTagsResponse> Handle(GetAllBlogTagsRequest request, CancellationToken cancellationToken)
    {
        return blogTagService.GetAllBlogTags(request);
    }
}