using Hcd.Application.Manages.Management;
using Hcd.Common.Exceptions;
using Hcd.Common.Models;
using Hcd.Common.Requests.Category;
using Hcd.Data.Entities.Management.Blog;
using Hcd.Data.Instances;

namespace Hcd.Application.Services.Management
{
    public class CategoryService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private CategoryManager CategoryManager => GetService<CategoryManager>();

        public async Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request)
        {
            var category = CategoryManager.GetAll(request.Search, request.Filter);
            var paginationResponse = await PaginationResponse<Category>.Create(
                category,
                request
            );

            return Mapper.Map<GetAllCategoriesResponse>(paginationResponse);
        }

        public async Task<GetDetailCategoryResponse> GetDetailCategory(GetDetailCategoryRequest request)
        {
            var category = await CategoryManager.FindAsync(request.Id) ?? throw new NotFoundException($"category with {request.Id} not found!!");

            var response = Mapper.Map<GetDetailCategoryResponse>(category);
            return response;
        }

        public async Task<CreateCategoryResponse> CreateCategory(CreateCategoryRequest request)
        {
            var newCategory = request.Adapt<Category>();
            await CategoryManager.AddAsync(newCategory);
            await UnitOfWork.SaveChangesAsync();
            var response = Mapper.Map<CreateCategoryResponse>(newCategory);
            return response;
        }

        public async Task DeleteCategory(DeleteCategoryRequest request)
        {
            CategoryManager.Delete(request.Id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<UpdateCategoryResponse> UpdateCategory(UpdateCategoryRequest request)
        {
            var category = await CategoryManager.FindAsync(request.Id) ?? throw new NotFoundException($"category with {request.Id} not found!!");
            var updatedCategory = request.Adapt(category);

            await CategoryManager.Update(category);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<UpdateCategoryResponse>(updatedCategory);
        }
    }
}