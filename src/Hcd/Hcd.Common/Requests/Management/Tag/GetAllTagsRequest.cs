using Hcd.Common.Enums;
using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Management.Tag;

public class GetAllTagsRequest : PaginationRequest, IRequest<GetAllTagsResponse>
{ };
public class GetAllTagsResponse : PaginationResponse<GetAllTagsResponseItem>
{
};
public class GetAllTagsResponseItem
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<BlogTags>? BlogTags { get; set; }
};

public class BlogTags
{
    public Guid Id { get; set; }
    public Guid BlogId { get; set; }
    public Guid TagId { get; set; }
    public Blogs? Blog { get; set; }
}

public class Blogs
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Thumbnail { get; set; }
    public int Rating { get; set; }
    public BlogStatusEnums Status { get; set; }
    public required string Slug { get; set; }

}