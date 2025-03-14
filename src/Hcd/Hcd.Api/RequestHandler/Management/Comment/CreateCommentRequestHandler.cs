using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Comment;

public class CreateCommentRequestHandler(CommentService commentService) : IRequestHandler<CreateCommentRequest, CreateCommentResponse>
{
    public Task<CreateCommentResponse> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        return commentService.CreateComment(request);
    }
}