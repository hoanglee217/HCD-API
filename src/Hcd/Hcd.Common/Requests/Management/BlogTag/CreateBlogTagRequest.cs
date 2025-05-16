using MediatR;

namespace Hcd.Common.Requests.Management.BlogTag;

public class CreateBlogTagRequest : IRequest<CreateBlogTagResponse>
{
    public required Guid BlogId { get; set; }
    public required Guid TagId { get; set; }
}

public class CreateBlogTagResponse
{
     public Guid Id { get; set; }
    public required Guid BlogId { get; set; }
    public required Guid TagId { get; set; }
}
