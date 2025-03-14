using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Comment;

public class DeleteCommentRequestHandler(CommentService commentService) : IRequestHandler<DeleteCommentRequest>
{
    public Task Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        return commentService.DeleteComment(request);
    }
}