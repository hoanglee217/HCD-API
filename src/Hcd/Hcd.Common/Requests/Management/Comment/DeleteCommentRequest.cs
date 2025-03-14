using MediatR;

namespace Hcd.Common.Requests.Management.Comment;

public class DeleteCommentRequest : IRequest
{
    public Guid Id { get; set; }
};