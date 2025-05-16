using Hcd.Common.Enums;
using MediatR;

namespace Hcd.Common.Requests.Management.Blog;

public class UpdateBlogRequest : IRequest<UpdateBlogResponse>
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public required string Slug { get; set; }
    public string? Thumbnail { get; set; }
    public BlogStatusEnums Status { get; set; }
    public List<Guid>? Categories { get; set; }
    public List<string>? Tags { get; set; }
};
public class UpdateBlogResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public int Rating { get; set; }
    public required string Slug { get; set; }
    public BlogStatusEnums Status { get; set; }
    public UserDto User { get; set; } = new UserDto();
    public ICollection<BlogCategoryDto> BlogCategories { get; set; } = new List<BlogCategoryDto>();
    public ICollection<BlogTagDto> BlogTags { get; set; } = new List<BlogTagDto>();
};