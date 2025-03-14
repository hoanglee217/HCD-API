using MediatR;

namespace Hcd.Common.Requests.Management.BlogCategory;


public class GetDetailBlogCategoryRequest : IRequest<GetDetailBlogCategoryResponse>
{
    public required Guid Id { get; set; }
};
public class GetDetailBlogCategoryResponse
{
    public required Guid BlogId { get; set; }
    public required Guid CategoryId { get; set; }
};