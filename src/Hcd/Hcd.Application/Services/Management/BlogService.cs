using Hcd.Common.Models;
using Hcd.Data.Instances;
using Hcd.Common.Exceptions;
using Hcd.Common.Requests.Management.Blog;

using Hcd.Data.Entities.Management;
using Hcd.Application.Manages.Management;

namespace Hcd.Application.Services.Management
{
    public class BlogService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private BlogManager BlogManager => GetService<BlogManager>();

        public async Task<GetAllBlogsResponse> GetAllBlogs(GetAllBlogsRequest request)
        {
            var blogs = BlogManager.GetAll().Include(b => b.User).Include(b => b.BlogCategories).ThenInclude(bc => bc.Category);

            var paginationResponse = await PaginationResponse<Blog>.Create(
            blogs,
            request
        );
            Console.WriteLine($"Debug: {paginationResponse.Items.FirstOrDefault()?.BlogCategories.Count} categories found");

            var response = Mapper.Map<GetAllBlogsResponse>(paginationResponse);
            return response;
        }

        public async Task<GetDetailBlogsResponse> GetDetailBlog(GetDetailBlogsRequest request)
        {
            var blog = await BlogManager.GetAll().Include(b => b.User).Include(b => b.BlogCategories).ThenInclude(bc => bc.Category).FirstOrDefaultAsync(o => o.Id == request.Id) ?? throw new NotFoundException($"blog with {request.Id} not found!!");

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