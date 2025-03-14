using Hcd.Application.Services.Management;
using Hcd.Common.Requests.Management.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Management.Comment;

public class GetAllCommentsRequestHandler(CommentService commentService) : IRequestHandler<GetAllCommentsRequest, GetAllCommentsResponse>
{
    public Task<GetAllCommentsResponse> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
    {
        return commentService.GetAllComments(request);
    }
}