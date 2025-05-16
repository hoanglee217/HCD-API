using Hcd.Common.Requests.Management.BlogTag;
using Hcd.Application.Services.Management;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogTag;

public class UpdateBlogTagHandler(BlogTagService blogTagService) : IRequestHandler<UpdateBlogTagRequest, UpdateBlogTagResponse>
{
    public Task<UpdateBlogTagResponse> Handle(UpdateBlogTagRequest request, CancellationToken cancellationToken)
    {
        return blogTagService.UpdateBlogTag(request);
    }
}