using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Management.BlogCategory;

public class GetAllBlogCategoriesRequest : IRequest<GetAllBlogCategoriesResponse>
{
};
public class GetAllBlogCategoriesResponse
{
    public required Guid BlogId { get; set; }
    public required Guid BlogCategoryId { get; set; }
};