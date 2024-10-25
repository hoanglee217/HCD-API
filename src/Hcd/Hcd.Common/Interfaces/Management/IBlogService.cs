using Hcd.Common.Requests.Blog;

namespace Hcd.Common.Interfaces.Management
{
    public interface IBlogService
    {
        Task<List<GetAllBlogsResponse>> GetAllBlogs(GetAllBlogsRequest request, CancellationToken cancellationToken);
        Task<GetDetailBlogsResponse> GetDetailBlog(GetDetailBlogsRequest request, CancellationToken cancellationToken);
        Task<CreateBlogResponse> CreateBlog(CreateBlogRequest request, CancellationToken cancellationToken);
        Task<UpdateBlogResponse> UpdateBlog(UpdateBlogRequest request, CancellationToken cancellationToken);
        Task DeleteBlog(DeleteBlogRequest request, CancellationToken cancellationToken);
    }
}