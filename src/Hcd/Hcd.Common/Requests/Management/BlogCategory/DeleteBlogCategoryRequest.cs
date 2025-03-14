using MediatR;

namespace Hcd.Common.Requests.Management.BlogCategory;


public class DeleteBlogCategoryRequest : IRequest
{
    public required Guid Id { get; set; }
};