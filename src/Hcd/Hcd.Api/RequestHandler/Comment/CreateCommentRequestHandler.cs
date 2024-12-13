using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class CreateCommentRequestHandler(CommentService commentService) : IRequestHandler<CreateCommentRequest, CreateCommentResponse>
{
    public Task<CreateCommentResponse> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        return commentService.CreateComment(request);
    }
}