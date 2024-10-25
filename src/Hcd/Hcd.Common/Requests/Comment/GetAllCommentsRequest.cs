using MediatR;

namespace Hcd.Common.Requests.Comment;

public class GetAllCommentsRequest : IRequest<GetAllCommentsResponse>
{
};
public class GetAllCommentsResponse
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
};