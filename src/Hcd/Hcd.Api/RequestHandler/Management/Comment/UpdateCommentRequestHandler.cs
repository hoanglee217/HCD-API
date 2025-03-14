using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Comment;

public class UpdateCommentRequestHandler(CommentService commentService) : IRequestHandler<UpdateCommentRequest, UpdateCommentResponse>
{
    public Task<UpdateCommentResponse> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        return commentService.UpdateComment(request);
    }
}