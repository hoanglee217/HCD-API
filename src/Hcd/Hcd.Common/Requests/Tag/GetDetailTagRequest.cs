using MediatR;

namespace Hcd.Common.Requests.Tag;

public class GetDetailTagRequest : IRequest<GetDetailTagResponse>
{
    public Guid Id { get; set; }
};
public class GetDetailTagResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid PostId  {get; set; }
};