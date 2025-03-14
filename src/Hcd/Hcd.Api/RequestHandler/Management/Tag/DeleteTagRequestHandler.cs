using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Tag;

public class DeleteTagRequestHandler(TagService tagService) : IRequestHandler<DeleteTagRequest>
{
    public Task Handle(DeleteTagRequest request, CancellationToken cancellationToken)
    {
        return tagService.DeleteTag(request);
    }
}