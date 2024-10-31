using Hcd.Application.Common.Interfaces;
using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Blog;
using Hcd.Data.Entities.Management.Blog;
using Mapster;
using MapsterMapper;

namespace Hcd.Application.Services.Management
{
    public class BlogService(
        IRepository<Blog> blogRepository,
        IMapper mapper,
        ICurrentUserService? currentUserService
    ) : IBlogService        
    {
        private readonly IRepository<Blog> _blogRepository = blogRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetAllBlogsResponse>> GetAllBlogs(GetAllBlogsRequest request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetAllAsync();
            var response = _mapper.Map<List<GetAllBlogsResponse>>(blog);
            return response;
        }

        public async Task<GetDetailBlogsResponse> GetDetailBlog(GetDetailBlogsRequest request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIdAsync(request.Id);
            var response = _mapper.Map<GetDetailBlogsResponse>(blog);
            return response;
        }
        
        public async Task<CreateBlogResponse> CreateBlog(CreateBlogRequest request, CancellationToken cancellationToken)
        {
            var newBlog = request.Adapt<Blog>();
            newBlog.UserId = currentUserService!.GetCurrentUserId();
            await _blogRepository.AddAsync(newBlog);
            var response = _mapper.Map<CreateBlogResponse>(newBlog);
            return response;
        }

        public async Task DeleteBlog(DeleteBlogRequest request, CancellationToken cancellationToken)
        {
            await _blogRepository.DeleteAsync(request.Id);
        }

        public async Task<UpdateBlogResponse> UpdateBlog(UpdateBlogRequest request, CancellationToken cancellationToken)
        {
            var blog = request.Adapt<Blog>();
            blog.UserId = currentUserService!.GetCurrentUserId();
            await _blogRepository.UpdateAsync(blog);
            var response = _mapper.Map<UpdateBlogResponse>(blog);
            return response;
        }
    }
}