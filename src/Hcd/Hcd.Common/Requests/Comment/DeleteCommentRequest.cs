using MediatR;

namespace Hcd.Common.Requests.Comment;

public class DeleteCommentRequest : IRequest
{
    public Guid Id { get; set; }
};