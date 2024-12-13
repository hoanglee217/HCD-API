using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class GetAllTagsRequestHandler(TagService tagService) : IRequestHandler<GetAllTagsRequest, GetAllTagsResponse>
{
    public Task<GetAllTagsResponse> Handle(GetAllTagsRequest request, CancellationToken cancellationToken)
    {
        return tagService.GetAllTags(request);
    }
}