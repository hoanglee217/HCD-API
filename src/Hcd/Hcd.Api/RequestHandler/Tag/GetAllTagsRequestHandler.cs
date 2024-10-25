using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class GetAllTagsRequestHandler(ITagService tagService) : IRequestHandler<GetAllTagsRequest, GetAllTagsResponse>
{
    public async Task<GetAllTagsResponse> Handle(GetAllTagsRequest request, CancellationToken cancellationToken)
    {
        return await tagService.GetAllTags(request, cancellationToken);
    }
}