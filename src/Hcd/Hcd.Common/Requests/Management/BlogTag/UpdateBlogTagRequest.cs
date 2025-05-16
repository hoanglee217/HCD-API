using MediatR;

namespace Hcd.Common.Requests.Management.BlogTag;

public class UpdateBlogTagRequest : IRequest<UpdateBlogTagResponse>
{
    public Guid Id { get; set; }
    public required Guid BlogId { get; set; }
    public required Guid TagId { get; set; }
}

public class UpdateBlogTagResponse
{
    public Guid Id { get; set; }
    public required Guid BlogId { get; set; }
    public required Guid TagId { get; set; }
}
