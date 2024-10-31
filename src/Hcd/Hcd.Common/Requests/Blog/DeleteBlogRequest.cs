using MediatR;

namespace Hcd.Common.Requests.Blog;

public class DeleteBlogRequest : IRequest
{
    public Guid Id { get; set; }
};