using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class GetDetailTagRequestHandler(ITagService tagService) : IRequestHandler<GetDetailTagRequest, GetDetailTagResponse>
{
    public async Task<GetDetailTagResponse> Handle(GetDetailTagRequest request, CancellationToken cancellationToken)
    {
        return await tagService.GetDetailTag(request, cancellationToken);
    }
}