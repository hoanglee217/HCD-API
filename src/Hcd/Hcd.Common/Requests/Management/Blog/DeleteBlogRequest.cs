using MediatR;

namespace Hcd.Common.Requests.Management.Blog;

public class DeleteBlogRequest : IRequest
{
    public Guid Id { get; set; }
};