using Hcd.Common.Enums;
using MediatR;

namespace Hcd.Common.Requests.Category;

public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
{
    public required string Name { get; set; }
    public int Position { get; set; }
    public  Guid? ParentId { get; set; }
    public CategoryEnums CategoryEnums { get; set; }
    public Guid PostId { get; set; }
};
public class CreateCategoryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Position { get; set; }
    public  Guid? ParentId { get; set; }
    public CategoryEnums CategoryEnums { get; set; }
    public Guid PostId { get; set; }
};