using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class DeleteTagRequestHandler(ITagService tagService) : IRequestHandler<DeleteTagRequest>
{
    public Task Handle(DeleteTagRequest request, CancellationToken cancellationToken)
    {
        return tagService.DeleteTag(request, cancellationToken);
    }
}