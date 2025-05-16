using Hcd.Common.Models;
using Hcd.Data.Instances;
using Hcd.Common.Exceptions;
using Hcd.Common.Requests.Management.Blog;

using Hcd.Data.Entities.Management;
using Hcd.Application.Managers.Management;

namespace Hcd.Application.Services.Management
{
    public class BlogService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private BlogManager BlogManager => GetService<BlogManager>();

        public async Task<GetAllBlogsResponse> GetAllBlogs(GetAllBlogsRequest request)
        {
            var blogs = BlogManager.GetAll();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                blogs = blogs.Where(o => o.Title.Contains(request.Search));
            }

            var responseBlog = blogs.Include(b => b.User)
            .Include(b => b.BlogCategories).ThenInclude(bc => bc.Category).OrderByDescending(o => o.Id);
            
            var paginationResponse = await PaginationResponse<Blog>.Create(
            responseBlog,
            request
        );
            var response = Mapper.Map<GetAllBlogsResponse>(paginationResponse);
            return response;
        }

        public async Task<GetDetailBlogsResponse> GetDetailBlog(GetDetailBlogsRequest request)
        {
            var blog = await BlogManager.GetAll()
            .Include(b => b.User)
            .Include(b => b.BlogCategories).ThenInclude(bc => bc.Category)
            .Include(b => b.BlogTags).ThenInclude(bc => bc.Tag)
            .FirstOrDefaultAsync(o => o.Id == request.Id) ?? throw new NotFoundException($"blog with {request.Id} not found!!");

            return Mapper.Map<GetDetailBlogsResponse>(blog);
        }

        public async Task<CreateBlogResponse> CreateBlog(CreateBlogRequest request)
        {
            var newBlog = request.Adapt<Blog>();
            newBlog.UserId = CurrentUser.GetCurrentUserId();
            await BlogManager.AddAsync(newBlog);

            await UnitOfWork.SaveChangesAsync();

            var response = Mapper.Map<CreateBlogResponse>(newBlog);

            await BlogManager.UpdateCategoriesAsync(response.Id, request.Categories);
            await BlogManager.UpdateTagsAsync(response.Id, request.Tags);

            await UnitOfWork.SaveChangesAsync();

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

            await BlogManager.UpdateCategoriesAsync(blog.Id, request.Categories);

            await BlogManager.UpdateTagsAsync(blog.Id, request.Tags);

            await BlogManager.Update(blog);
            await UnitOfWork.SaveChangesAsync();

            var updatedBlog = request.Adapt(blog);

            return Mapper.Map<UpdateBlogResponse>(updatedBlog);
        }
    }
}