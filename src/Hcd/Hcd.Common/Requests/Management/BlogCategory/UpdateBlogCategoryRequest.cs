using MediatR;

namespace Hcd.Common.Requests.Management.BlogCategory;


public class UpdateBlogCategoryRequest : IRequest<UpdateBlogCategoryResponse>
{
    public required Guid Id { get; set; }
};
public class UpdateBlogCategoryResponse
{
    public required Guid BlogId { get; set; }
    public required Guid CategoryId { get; set; }
};