using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class GetDetailTagRequestHandler(TagService tagService) : IRequestHandler<GetDetailTagRequest, GetDetailTagResponse>
{
    public Task<GetDetailTagResponse> Handle(GetDetailTagRequest request, CancellationToken cancellationToken)
    {
        return tagService.GetDetailTag(request);
    }
}