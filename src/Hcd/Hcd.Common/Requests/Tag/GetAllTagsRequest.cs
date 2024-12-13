using Hcd.Common.Models;
using MediatR;

namespace Hcd.Common.Requests.Tag;

public class GetAllTagsRequest : PaginationRequest, IRequest<GetAllTagsResponse>
{};
public class GetAllTagsResponse : PaginationResponse<GetAllTagsResponseItem>
{
};
public class GetAllTagsResponseItem
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid BlogId  {get; set; }
}