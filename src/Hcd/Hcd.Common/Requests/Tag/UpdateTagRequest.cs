using MediatR;

namespace Hcd.Common.Requests.Tag;

public class UpdateTagRequest : IRequest<UpdateTagResponse>
{
    public required string Name { get; set; }
    public Guid PostId  {get; set; }
};
public class UpdateTagResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid PostId  {get; set; }
};