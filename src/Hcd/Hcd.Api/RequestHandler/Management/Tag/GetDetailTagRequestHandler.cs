using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Tag;

public class GetDetailTagRequestHandler(TagService tagService) : IRequestHandler<GetDetailTagRequest, GetDetailTagResponse>
{
    public Task<GetDetailTagResponse> Handle(GetDetailTagRequest request, CancellationToken cancellationToken)
    {
        return tagService.GetDetailTag(request);
    }
}