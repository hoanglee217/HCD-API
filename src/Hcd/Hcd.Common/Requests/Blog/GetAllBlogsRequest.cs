using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Blog;

public class GetAllBlogsRequest : PaginationRequest, IRequest<GetAllBlogsResponse>
{
};
public class GetAllBlogsResponse : PaginationResponse<GetAllBlogsResponseItem>
{
};
public class GetAllBlogsResponseItem
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public int Rating { get; set; }
    public required string Slug { get; set; }
    public required Guid CategoryId { get; set; }
    public required Guid UserId { get; set; }
};