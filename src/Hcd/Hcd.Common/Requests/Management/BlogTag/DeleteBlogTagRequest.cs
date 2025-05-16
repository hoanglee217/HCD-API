using MediatR;

namespace Hcd.Common.Requests.Management.BlogTag;

public class DeleteBlogTagRequest: IRequest
{
    public Guid Id { get; set; }
}