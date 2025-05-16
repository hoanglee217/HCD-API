using MediatR;

namespace Hcd.Common.Requests.Management.BlogTag;

public class GetDetailBlogTagRequest : IRequest<GetDetailBlogTagResponse>
{
    public required Guid Id { get; set; }
}

public class GetDetailBlogTagResponse
{
    public Guid Id { get; set; }
    public required Guid BlogId { get; set; }
    public required Guid TagId { get; set; }
}
