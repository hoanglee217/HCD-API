using Hcd.Common.Enums;
using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Management.Blog;

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
    public int Rating { get; set; }
    public required string Slug { get; set; }
    public BlogStatusEnums Status { get; set; }
    public UserDto User { get; set; } = new UserDto();
    public ICollection<BlogCategoryDto> BlogCategories { get; set; } = new List<BlogCategoryDto>();
};

public class UserDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
public class BlogCategoryDto
{
    public Guid Id { get; set; }
    public CategoryDto? Category { get; set; }
}
public class CategoryDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public CategoryEnums? CategoryEnums { get; set; }
}

public class BlogTagDto
{
    public Guid Id { get; set; }
    public TagDto? Tag { get; set; }
}
public class TagDto
{
    public Guid? Id { get; set; }
    public required string Name { get; set; }
}
