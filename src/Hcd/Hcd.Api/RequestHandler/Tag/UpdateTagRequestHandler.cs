using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class UpdateTagRequestHandler(TagService tagService) : IRequestHandler<UpdateTagRequest, UpdateTagResponse>
{
    public Task<UpdateTagResponse> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
    {
        return tagService.UpdateTag(request);
    }
}