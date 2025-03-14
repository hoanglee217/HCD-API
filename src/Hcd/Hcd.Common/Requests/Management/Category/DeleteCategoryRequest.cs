using MediatR;

namespace Hcd.Common.Requests.Management.Category;

public class DeleteCategoryRequest : IRequest
{
    public Guid Id { get; set; }
};