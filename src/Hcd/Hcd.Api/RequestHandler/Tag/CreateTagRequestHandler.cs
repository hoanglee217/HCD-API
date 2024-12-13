using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Tag;
using MediatR;

namespace Hcd.Api.RequestHandler.Tag;

public class CreateTagRequestHandler(TagService tagService) : IRequestHandler<CreateTagRequest, CreateTagResponse>
{
    public Task<CreateTagResponse> Handle(CreateTagRequest request, CancellationToken cancellationToken)
    {
        return tagService.CreateTag(request);
    }
}