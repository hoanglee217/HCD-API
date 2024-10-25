using MediatR;

namespace Hcd.Common.Requests.Comment;

public class CreateCommentRequest : IRequest<CreateCommentResponse>
{
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
};
public class CreateCommentResponse
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
};