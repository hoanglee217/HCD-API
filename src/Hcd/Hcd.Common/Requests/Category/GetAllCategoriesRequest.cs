using Hcd.Common.Enums;
using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Category;

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
};