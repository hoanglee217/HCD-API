using MediatR;

namespace Hcd.Common.Requests.Management.Comment;

public class CreateCommentRequest : IRequest<CreateCommentResponse>
{
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid BlogId { get; set; }
};
public class CreateCommentResponse
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid BlogId { get; set; }
};