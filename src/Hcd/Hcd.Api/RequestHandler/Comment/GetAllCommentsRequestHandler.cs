using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class GetAllCommentsRequestHandler(CommentService commentService) : IRequestHandler<GetAllCommentsRequest, GetAllCommentsResponse>
{
    public Task<GetAllCommentsResponse> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
    {
        return commentService.GetAllComments(request);
    }
}