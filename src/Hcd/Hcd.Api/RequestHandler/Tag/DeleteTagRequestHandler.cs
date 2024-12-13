using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class DeleteTagRequestHandler(TagService tagService) : IRequestHandler<DeleteTagRequest>
{
    public Task Handle(DeleteTagRequest request, CancellationToken cancellationToken)
    {
        return tagService.DeleteTag(request);
    }
}