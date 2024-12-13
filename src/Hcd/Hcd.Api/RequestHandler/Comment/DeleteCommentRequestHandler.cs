using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class DeleteCommentRequestHandler(CommentService commentService) : IRequestHandler<DeleteCommentRequest>
{
    public Task Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        return commentService.DeleteComment(request);
    }
}