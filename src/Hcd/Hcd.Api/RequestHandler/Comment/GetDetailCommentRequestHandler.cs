using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class GetDetailCommentRequestHandler(ICommentService commentService) : IRequestHandler<GetDetailCommentRequest, GetDetailCommentResponse>
{
    private readonly ICommentService _commentService = commentService;
    public async Task<GetDetailCommentResponse> Handle(GetDetailCommentRequest request, CancellationToken cancellationToken)
    {
        return await _commentService.GetDetailComment(request, cancellationToken);
    }
}