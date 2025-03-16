using Hcd.Common.Enums;
using MediatR;

namespace Hcd.Common.Requests.Management.Blog;

public class UpdateBlogRequest : IRequest<UpdateBlogResponse>
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public int Rating { get; set; }
    public required string Slug { get; set; }
    public BlogStatusEnums Status { get; set; }
    public UserDto User { get; set; } = new UserDto();
    public ICollection<BlogCategortDto> BlogCategories { get; set; } = new List<BlogCategortDto>();
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
    public ICollection<BlogCategortDto> BlogCategories { get; set; } = new List<BlogCategortDto>();
};