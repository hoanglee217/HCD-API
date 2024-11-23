using MediatR;

namespace Hcd.Common.Requests.Blog;

public class CreateBlogRequest : IRequest<CreateBlogResponse>
{
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public required Guid CategoryId { get; set; }
    public required Guid UserId { get; set; }
};
public class CreateBlogResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public int Rating { get; set; }
    public required string Slug { get; set; }
};