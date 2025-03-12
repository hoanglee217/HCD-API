using Hcd.Application.Manages.Management;
using Hcd.Common.Exceptions;
using Hcd.Common.Interfaces;
using Hcd.Common.Models;
using Hcd.Common.Requests.Blog;
using Hcd.Data.Entities.Management;
using Hcd.Data.Instances;
namespace Hcd.Application.Services.Management
{
    public class BlogService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private BlogManager BlogManager => GetService<BlogManager>();

        public async Task<GetAllBlogsResponse> GetAllBlogs(GetAllBlogsRequest request)
        {
            var blogs = BlogManager.GetAll(request.Search, request.Filter);

            var paginationResponse = await PaginationResponse<Blog>.Create(
            blogs,
            request
        );

            return Mapper.Map<GetAllBlogsResponse>(paginationResponse);
        }

        public async Task<GetDetailBlogsResponse> GetDetailBlog(GetDetailBlogsRequest request)
        {
            var blog = await BlogManager.FindAsync(request.Id) ?? throw new NotFoundException($"blog with {request.Id} not found!!");

            return Mapper.Map<GetDetailBlogsResponse>(blog);
        }

        public async Task<CreateBlogResponse> CreateBlog(CreateBlogRequest request)
        {
            var newBlog = request.Adapt<Blog>();
            newBlog.UserId = CurrentUser.GetCurrentUserId();

            await BlogManager.AddAsync(newBlog);

            await UnitOfWork.SaveChangesAsync();

            var response = Mapper.Map<CreateBlogResponse>(newBlog);
            return response;
        }

        public async Task DeleteBlog(DeleteBlogRequest request)
        {
            BlogManager.Delete(request.Id);
            await UnitOfWork.SaveChangesAsync();

        }

        public async Task<UpdateBlogResponse> UpdateBlog(UpdateBlogRequest request)
        {
            var blog = await BlogManager.FindAsync(request.Id) ?? throw new NotFoundException($"blog with {request.Id} not found!!");
            var updatedBlog = request.Adapt(blog);

            await BlogManager.Update(blog);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<UpdateBlogResponse>(updatedBlog);
        }
    }
}