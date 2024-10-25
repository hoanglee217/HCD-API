using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class CreateTagRequestHandler(ITagService tagService) : IRequestHandler<CreateTagRequest, CreateTagResponse>
{
    public async Task<CreateTagResponse> Handle(CreateTagRequest request, CancellationToken cancellationToken)
    {
        return await tagService.CreateTag(request, cancellationToken);
    }
}