using Hcd.Common.Enums;
using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Management.Category;

public class GetAllCategoriesRequest : PaginationRequest, IRequest<GetAllCategoriesResponse>
{
};
public class GetAllCategoriesResponse : PaginationResponse<GetAllCategoriesResponseItem>
{
};
public class GetAllCategoriesResponseItem
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Position { get; set; }
    public  Guid? ParentId { get; set; }
    public CategoryEnums CategoryEnums { get; set; }
    public List<GetAllCategoriesResponseItem>? Children { get; set; }
    public List<string> Categories { get; set; } = new();
};