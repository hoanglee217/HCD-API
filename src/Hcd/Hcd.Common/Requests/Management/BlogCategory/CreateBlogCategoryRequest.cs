using MediatR;

namespace Hcd.Common.Requests.Management.BlogCategory;

public class CreateBlogCategoryRequest : IRequest<CreateBlogCategoryResponse>
{
    public required Guid BlogId { get; set; }
    public required Guid CategoryId { get; set; }
}

public class CreateBlogCategoryResponse
{
    public required Guid Id { get; set; }
    public required Guid BlogId { get; set; }
    public required Guid CategoryId { get; set; }
}