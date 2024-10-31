using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class UpdateTagRequestHandler(ITagService tagService) : IRequestHandler<UpdateTagRequest, UpdateTagResponse>
{
    public async Task<UpdateTagResponse> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
    {
        return await tagService.UpdateTag(request, cancellationToken);
    }
}