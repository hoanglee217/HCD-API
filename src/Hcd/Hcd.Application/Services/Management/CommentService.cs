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
        IMapper mapper
    ) : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository = commentRepository;
        private readonly IMapper _mapper = mapper;
        public Task<CreateCommentResponse> CreateComment(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var newComment = request.Adapt<Comment>();
            _commentRepository.Add(newComment);
            var response = _mapper.Map<CreateCommentResponse>(newComment);
            return Task.FromResult(response);
        }

        public Task DeleteComment(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            _commentRepository.Delete(request.Id);
            throw new NotImplementedException();
        }

        public Task<GetAllCommentsResponse> GetAllComments(GetAllCommentsRequest request, CancellationToken cancellationToken)
        {
            var comment = _commentRepository.GetAll();
            var response = _mapper.Map<GetAllCommentsResponse>(comment);
            return Task.FromResult(response);
        }

        public Task<GetDetailCommentResponse> GetDetailComment(GetDetailCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = _commentRepository.GetById(request.Id);
            var response = _mapper.Map<GetDetailCommentResponse>(comment);
            return Task.FromResult(response);
        }

        public Task<UpdateCommentResponse> UpdateComment(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            
            var comment = request.Adapt<Comment>();
            _commentRepository.Update(comment);
            var response = _mapper.Map<UpdateCommentResponse>(comment);
            return Task.FromResult(response);
        }
    }
}