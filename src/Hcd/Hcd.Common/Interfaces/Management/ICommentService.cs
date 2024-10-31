using Hcd.Common.Requests.Comment;

namespace Hcd.Common.Interfaces.Management
{
    public interface ICommentService
    {
        Task<List<GetAllCommentsResponse>> GetAllComments(GetAllCommentsRequest request, CancellationToken cancellationToken);
        Task<GetDetailCommentResponse> GetDetailComment(GetDetailCommentRequest request, CancellationToken cancellationToken);
        Task<CreateCommentResponse> CreateComment(CreateCommentRequest request, CancellationToken cancellationToken);
        Task<UpdateCommentResponse> UpdateComment(UpdateCommentRequest request, CancellationToken cancellationToken);
        Task DeleteComment(DeleteCommentRequest request, CancellationToken cancellationToken);
    }
}