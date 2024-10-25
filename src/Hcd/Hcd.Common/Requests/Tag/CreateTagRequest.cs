using MediatR;

namespace Hcd.Common.Requests.Tag;

public class CreateTagRequest : IRequest<CreateTagResponse>
{
    public required string Name { get; set; }
    public Guid PostId { get; set; }
};
public class CreateTagResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid PostId  {get; set; }
};