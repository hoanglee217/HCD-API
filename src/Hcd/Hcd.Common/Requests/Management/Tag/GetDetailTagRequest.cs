using MediatR;

namespace Hcd.Common.Requests.Management.Tag;

public class GetDetailTagRequest : IRequest<GetDetailTagResponse>
{
    public Guid Id { get; set; }
};
public class GetDetailTagResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public BlogTags[]? BlogTags  {get; set; }
};