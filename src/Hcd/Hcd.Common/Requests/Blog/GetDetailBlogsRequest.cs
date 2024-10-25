using MediatR;

namespace Hcd.Common.Requests.Blog;

public class GetDetailBlogsRequest : IRequest<GetDetailBlogsResponse>
{
    public Guid Id { get; set; }
};
public class GetDetailBlogsResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public int Rating { get; set; }
    public required string Slug { get; set; }
};