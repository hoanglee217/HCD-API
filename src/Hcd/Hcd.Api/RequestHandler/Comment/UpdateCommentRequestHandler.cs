using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class UpdateCommentRequestHandler(ICommentService commentService) : IRequestHandler<UpdateCommentRequest, UpdateCommentResponse>
{
    private readonly ICommentService _commentService = commentService;
    public async Task<UpdateCommentResponse> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        return await _commentService.UpdateComment(request, cancellationToken);
    }
}