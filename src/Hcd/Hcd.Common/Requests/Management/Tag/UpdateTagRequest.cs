using MediatR;

namespace Hcd.Common.Requests.Management.Tag;

public class UpdateTagRequest : IRequest<UpdateTagResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public BlogTags[]? BlogTags { get; set; }
};
public class UpdateTagResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public BlogTags[]? BlogTags { get; set; }
};