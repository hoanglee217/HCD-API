using MediatR;

namespace Hcd.Common.Requests.Management.Tag;

public class CreateTagRequest : IRequest<CreateTagResponse>
{
    public required string Name { get; set; }
    public Guid BlogId { get; set; }
};
public class CreateTagResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid BlogId  {get; set; }
};