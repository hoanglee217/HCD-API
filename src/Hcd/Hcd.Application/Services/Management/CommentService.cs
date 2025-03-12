using Hcd.Application.Manages.Management;
using Hcd.Common.Exceptions;
using Hcd.Common.Models;
using Hcd.Common.Requests.Comment;
using Hcd.Data.Entities.Management;
using Hcd.Data.Instances;

namespace Hcd.Application.Services.Management
{
    public class CommentService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private CommentManager CommentManager => GetService<CommentManager>();

        public async Task<GetAllCommentsResponse> GetAllComments(GetAllCommentsRequest request)
        {
            var comment = CommentManager.GetAll(request.Search, request.Filter);
            var paginationResponse = await PaginationResponse<Comment>.Create(
                comment,
                request
            );

            return Mapper.Map<GetAllCommentsResponse>(paginationResponse);
        }

        public async Task<GetDetailCommentResponse> GetDetailComment(GetDetailCommentRequest request)
        {
            var comment = await CommentManager.FindAsync(request.Id) ?? throw new NotFoundException($"comment with {request.Id} not found!!");

            var response = Mapper.Map<GetDetailCommentResponse>(comment);
            return response;
        }

        public async Task<CreateCommentResponse> CreateComment(CreateCommentRequest request)
        {
            var newComment = request.Adapt<Comment>();
            await CommentManager.AddAsync(newComment);
            await UnitOfWork.SaveChangesAsync();
            var response = Mapper.Map<CreateCommentResponse>(newComment);
            return response;
        }

        public async Task DeleteComment(DeleteCommentRequest request)
        {
            CommentManager.Delete(request.Id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<UpdateCommentResponse> UpdateComment(UpdateCommentRequest request)
        {
            var comment = await CommentManager.FindAsync(request.Id) ?? throw new NotFoundException($"comment with {request.Id} not found!!");
            var updatedComment = request.Adapt(comment);

            await CommentManager.Update(comment);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<UpdateCommentResponse>(updatedComment);
        }
    }
}