using MediatR;

namespace Hcd.Common.Requests.Blog;

public class UpdateBlogRequest : IRequest<UpdateBlogResponse>
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public int? Rating { get; set; }
    public string? Slug { get; set; }
    public required Guid CategoryId { get; set; }
    public required Guid UserId { get; set; }
};
public class UpdateBlogResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public int? Rating { get; set; }
    public string? Slug { get; set; }
    public required Guid CategoryId { get; set; }
    public required Guid UserId { get; set; }
};