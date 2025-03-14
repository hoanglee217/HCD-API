using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Comment;

public class GetDetailCommentRequestHandler(CommentService commentService) : IRequestHandler<GetDetailCommentRequest, GetDetailCommentResponse>
{
    public Task<GetDetailCommentResponse> Handle(GetDetailCommentRequest request, CancellationToken cancellationToken)
    {
        return commentService.GetDetailComment(request);
    }
}