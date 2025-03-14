using MediatR;

namespace Hcd.Common.Requests.Management.Comment;

public class GetDetailCommentRequest : IRequest<GetDetailCommentResponse>
{
    public Guid Id { get; set; }
};
public record GetDetailCommentResponse
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid BlogId { get; set; }
};