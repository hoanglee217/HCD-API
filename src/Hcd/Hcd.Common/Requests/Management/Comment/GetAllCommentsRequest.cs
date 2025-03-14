using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Management.Comment;

public class GetAllCommentsRequest : PaginationRequest, IRequest<GetAllCommentsResponse>
{
};
public class GetAllCommentsResponse : PaginationResponse<GetAllCommentsResponseItem>
{
};
public class GetAllCommentsResponseItem
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid BlogId { get; set; }
};