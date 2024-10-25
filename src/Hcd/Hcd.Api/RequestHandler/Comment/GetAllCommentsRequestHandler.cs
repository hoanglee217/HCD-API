using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class GetAllCommentsRequestHandler(ICommentService commentService) : IRequestHandler<GetAllCommentsRequest, GetAllCommentsResponse>
{
    private readonly ICommentService _commentService = commentService;
    public async Task<GetAllCommentsResponse> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
    {
        return await _commentService.GetAllComments(request, cancellationToken);
    }
}