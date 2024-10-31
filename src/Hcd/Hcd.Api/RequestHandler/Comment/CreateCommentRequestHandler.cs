using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using MediatR;

namespace Hcd.Api.RequestHandler.Comment;

public class CreateCommentRequestHandler(ICommentService commentService) : IRequestHandler<CreateCommentRequest, CreateCommentResponse>
{
    public async Task<CreateCommentResponse> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        return await commentService.CreateComment(request, cancellationToken);
    }
}