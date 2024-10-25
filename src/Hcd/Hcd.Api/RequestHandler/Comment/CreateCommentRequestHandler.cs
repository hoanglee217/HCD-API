using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class CreateCommentRequestHandler(ICommentService commentService) : IRequestHandler<CreateCommentRequest, CreateCommentResponse>
{
    private readonly ICommentService _commentService = commentService;
    public async Task<CreateCommentResponse> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        return await _commentService.CreateComment(request, cancellationToken);
    }
}