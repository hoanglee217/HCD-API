using Hcd.Common.Requests.Management.BlogTag;
using Hcd.Application.Services.Management;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogTag;

public class GetDetailBlogTagHandler(BlogTagService blogTagService) : IRequestHandler<GetDetailBlogTagRequest, GetDetailBlogTagResponse>
{
    public Task<GetDetailBlogTagResponse> Handle(GetDetailBlogTagRequest request, CancellationToken cancellationToken)
    {
        return blogTagService.GetDetailBlogTag(request);
    }
}
