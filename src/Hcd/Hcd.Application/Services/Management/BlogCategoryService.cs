using Hcd.Application.Managers.Management;
using Hcd.Common.Exceptions;
using Hcd.Common.Interfaces;
using Hcd.Common.Models;
using Hcd.Common.Requests.Management.BlogCategory;

using Hcd.Data.Entities.Management;
using Hcd.Data.Instances;

namespace Hcd.Application.Services.Management
{
    public class BlogCategoryService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private BlogCategoryManager BlogCategoryManager => GetService<BlogCategoryManager>();

        public async Task<GetAllBlogCategoriesResponse> GetAllBlogCategory(GetAllBlogCategoriesRequest request)
        {
            var BlogCategory = await BlogCategoryManager.GetAll().ToListAsync();

            return Mapper.Map<GetAllBlogCategoriesResponse>(BlogCategory);
        }

        public async Task<GetDetailBlogCategoryResponse> GetDetailBlogCategory(GetDetailBlogCategoryRequest request)
        {
            var blogCategory = await BlogCategoryManager.FindAsync(request.Id)
                ?? throw new NotFoundException($"BlogCategory not found!!");

            return Mapper.Map<GetDetailBlogCategoryResponse>(blogCategory);
        }

        public async Task<CreateBlogCategoryResponse> CreateBlogCategory(CreateBlogCategoryRequest request)
        {
            var newBlogCategory = request.Adapt<BlogCategory>();

            await BlogCategoryManager.AddAsync(newBlogCategory);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<CreateBlogCategoryResponse>(newBlogCategory);
        }

        public async Task DeleteBlogCategory(DeleteBlogCategoryRequest request)
        {
            
            BlogCategoryManager.Delete(request.Id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<UpdateBlogCategoryResponse> UpdateBlogCategory(UpdateBlogCategoryRequest request)
        {
            var blogCategory = await BlogCategoryManager.FindAsync(request.Id)
                ?? throw new NotFoundException($"BlogCategory not found!!");

            var updatedBlogCategory = request.Adapt(blogCategory);

            await BlogCategoryManager.Update(updatedBlogCategory);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<UpdateBlogCategoryResponse>(updatedBlogCategory);
        }
    }
}