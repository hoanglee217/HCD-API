using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class GetAllCommentsRequestHandler(ICommentService commentService) : IRequestHandler<GetAllCommentsRequest, List<GetAllCommentsResponse>>
{
    public async Task<List<GetAllCommentsResponse>> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
    {
        return await commentService.GetAllComments(request, cancellationToken);
    }
}