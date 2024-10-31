using MediatR;

namespace Hcd.Common.Requests.Category;

public class DeleteCategoryRequest : IRequest
{
    public Guid Id { get; set; }
};