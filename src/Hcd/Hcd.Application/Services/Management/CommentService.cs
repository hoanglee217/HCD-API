using Hcd.Application.Common.Interfaces;
using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Comment;
using Hcd.Data.Entities.Management.Blog;
using Mapster;
using MapsterMapper;

namespace Hcd.Application.Services.Management
{
    public class CommentService(
        IRepository<Comment> commentRepository,
        ICurrentUserService currentUserService,   
        IMapper mapper
    ) : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository = commentRepository;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IMapper _mapper = mapper;
        
        public async Task<List<GetAllCommentsResponse>> GetAllComments(GetAllCommentsRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetAllAsync();
            var response = _mapper.Map<List<GetAllCommentsResponse>>(comment);
            return response;
        }

        public async Task<GetDetailCommentResponse> GetDetailComment(GetDetailCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            var response = _mapper.Map<GetDetailCommentResponse>(comment);
            return response;
        }

        public async Task<CreateCommentResponse> CreateComment(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var newComment = request.Adapt<Comment>();
            newComment.UserId = _currentUserService!.GetCurrentUserId();
            await _commentRepository.AddAsync(newComment);
            var response = _mapper.Map<CreateCommentResponse>(newComment);
            return response;
        }

        public async Task DeleteComment(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            await _commentRepository.DeleteAsync(request.Id);
        }

        public async Task<UpdateCommentResponse> UpdateComment(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = request.Adapt<Comment>();
            comment.UserId = _currentUserService!.GetCurrentUserId();
            await _commentRepository.UpdateAsync(comment);
            var response = _mapper.Map<UpdateCommentResponse>(comment);
            return response;
        }
    }
}