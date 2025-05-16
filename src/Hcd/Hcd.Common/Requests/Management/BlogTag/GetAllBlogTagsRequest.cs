using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Management.BlogTag;

public class GetAllBlogTagsRequest : PaginationRequest, IRequest<GetAllBlogTagsResponse>
{
}

public class GetAllBlogTagsResponse : PaginationResponse<GetAllBlogTagsResponseItem>
{
}

public class GetAllBlogTagsResponseItem
{
    public Guid Id { get; set; }
    public required Guid BlogId { get; set; }
    public required Guid TagId { get; set; }
}