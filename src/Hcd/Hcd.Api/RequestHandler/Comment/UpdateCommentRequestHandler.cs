using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class UpdateCommentRequestHandler(ICommentService commentService) : IRequestHandler<UpdateCommentRequest, UpdateCommentResponse>
{
    public async Task<UpdateCommentResponse> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        return await commentService.UpdateComment(request, cancellationToken);
    }
}