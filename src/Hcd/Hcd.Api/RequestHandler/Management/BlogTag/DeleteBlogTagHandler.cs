using Hcd.Common.Requests.Management.BlogTag;
using Hcd.Application.Services.Management;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.BlogTag;

public class DeleteBlogTagHandler(BlogTagService blogTagService) : IRequestHandler<DeleteBlogTagRequest>
{
    public Task Handle(DeleteBlogTagRequest request, CancellationToken cancellationToken)
    {
        return blogTagService.DeleteBlogTag(request);
    }
}
