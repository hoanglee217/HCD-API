using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class GetDetailCommentRequestHandler(CommentService commentService) : IRequestHandler<GetDetailCommentRequest, GetDetailCommentResponse>
{
    public Task<GetDetailCommentResponse> Handle(GetDetailCommentRequest request, CancellationToken cancellationToken)
    {
        return commentService.GetDetailComment(request);
    }
}