using MediatR;

namespace Hcd.Common.Requests.Management.Comment;

public record UpdateCommentRequest : IRequest<UpdateCommentResponse>
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid BlogId { get; set; }
};
public class UpdateCommentResponse
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid BlogId { get; set; }
};