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
        public Task<CreateBlogResponse> CreateBlog(CreateBlogRequest request, CancellationToken cancellationToken)
        {
            var newBlog = request.Adapt<Blog>();
            newBlog.UserId = currentUserService!.GetCurrentUserId();
            _blogRepository.Add(newBlog);
            var response = _mapper.Map<CreateBlogResponse>(newBlog);
            return Task.FromResult(response);
        }

        public async Task DeleteBlog(DeleteBlogRequest request, CancellationToken cancellationToken)
        {
            await _blogRepository.Delete(request.Id);
        }

        public Task<List<GetAllBlogsResponse>> GetAllBlogs(GetAllBlogsRequest request, CancellationToken cancellationToken)
        {
            var blog = _blogRepository.GetAll();
            var response = _mapper.Map<List<GetAllBlogsResponse>>(blog);
            return Task.FromResult(response);
        }

        public Task<GetDetailBlogsResponse> GetDetailBlog(GetDetailBlogsRequest request, CancellationToken cancellationToken)
        {
            var blog = _blogRepository.GetById(request.Id);
            var response = _mapper.Map<GetDetailBlogsResponse>(blog);
            return Task.FromResult(response);
        }

        public Task<UpdateBlogResponse> UpdateBlog(UpdateBlogRequest request, CancellationToken cancellationToken)
        {
            
            var blog = request.Adapt<Blog>();
            blog.UserId = currentUserService!.GetCurrentUserId();
            _blogRepository.Update(blog);
            var response = _mapper.Map<UpdateBlogResponse>(blog);
            return Task.FromResult(response);
        }
    }
}