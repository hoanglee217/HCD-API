using MediatR;

namespace Hcd.Common.Requests.Tag;

public class GetAllTagsRequest : IRequest<GetAllTagsResponse>
{};
public class GetAllTagsResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid PostId  {get; set; }
}