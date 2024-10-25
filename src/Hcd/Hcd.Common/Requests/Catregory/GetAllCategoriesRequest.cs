using Hcd.Common.Enums;
using MediatR;

namespace Hcd.Common.Requests.Category;

public class GetAllCategoriesRequest : IRequest<GetAllCategoriesResponse>
{
};
public class GetAllCategoriesResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Position { get; set; }
    public  Guid? ParentId { get; set; }
    public CategoryEnums CategoryEnums { get; set; }
    public Guid PostId { get; set; }
};