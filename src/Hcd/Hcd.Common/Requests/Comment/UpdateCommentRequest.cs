using MediatR;

namespace Hcd.Common.Requests.Comment;

public record UpdateCommentRequest : IRequest<UpdateCommentResponse>
{
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
};
public class UpdateCommentResponse
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
};