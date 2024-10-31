using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class GetDetailCommentRequestHandler(ICommentService commentService) : IRequestHandler<GetDetailCommentRequest, GetDetailCommentResponse>
{
    public async Task<GetDetailCommentResponse> Handle(GetDetailCommentRequest request, CancellationToken cancellationToken)
    {
        return await commentService.GetDetailComment(request, cancellationToken);
    }
}