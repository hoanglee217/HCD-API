using Hcd.Common.Requests.Management.BlogTag;
using Hcd.Application.Services.Management;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogTag;

public class CreateBlogTagHandler(BlogTagService blogTagService) : IRequestHandler<CreateBlogTagRequest, CreateBlogTagResponse>
{
    public Task<CreateBlogTagResponse> Handle(CreateBlogTagRequest request, CancellationToken cancellationToken)
    {
        return blogTagService.CreateBlogTag(request);
    }
}