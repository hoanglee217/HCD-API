using MediatR;

namespace Hcd.Common.Requests.Tag;

public class GetAllTagsRequest : IRequest<List<GetAllTagsResponse>>
{};
public class GetAllTagsResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid BlogId  {get; set; }
}