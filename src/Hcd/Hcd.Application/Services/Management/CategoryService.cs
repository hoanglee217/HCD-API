using System.Reflection.Metadata;
using Hcd.Application.Managers.Management;
using Hcd.Common.Enums;
using Hcd.Common.Exceptions;
using Hcd.Common.Models;
using Hcd.Common.Requests.Management.Category;
using Hcd.Data.Entities.Management;
using Hcd.Data.Instances;

namespace Hcd.Application.Services.Management
{
    public class CategoryService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private CategoryManager CategoryManager => GetService<CategoryManager>();

        public async Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request)
        {
            // if (request.Search != null)
            // {
            //     var matchedCategories = await CategoryManager.GetAll()
            //         .Where(c => EF.Functions.Like(c.Name, $"%{request.Search}%"))
            //         .ToListAsync();

            //     var childCategory = matchedCategories.Where(child => child.CategoryEnums != CategoryEnums.Primary).Distinct().ToList();
            //     var childCategoryIds = childCategory.Select(child => child.ParentId).Distinct().ToList();

            //     var parentCategories = CategoryManager.GetAll().Where(parent => childCategoryIds.Contains(parent.Id)).Distinct();

            //     var paginationResponse = await PaginationResponse<Category>.Create(
            //         parentCategories,
            //         request
            //     );
            //     var categories = BuildCategoryTree(paginationResponse.Items, childCategory);

            //     var response = Mapper.Map<GetAllCategoriesResponse>(paginationResponse);
            //     response.Items = categories;

            //     return response;
            // }
            // else
            // {
            var parentCategoriesQuery = CategoryManager.GetAll()
                .Where(x => x.CategoryEnums == CategoryEnums.Primary);

            if (request.Search != null)
            {
                parentCategoriesQuery = parentCategoriesQuery.Where(o => o.Name.Contains(request.Search));
            }
            
            var paginationResponse = await PaginationResponse<Category>.Create(
                parentCategoriesQuery,
                request
            );

            var childCategories = await CategoryManager.GetAll()
                .Where(x => x.CategoryEnums != CategoryEnums.Primary)
                .ToListAsync();
            var categories = BuildCategoryTree(paginationResponse.Items, childCategories);

            var response = Mapper.Map<GetAllCategoriesResponse>(paginationResponse);
            response.Items = categories;
            return response;
            // }
        }

        public async Task<GetDetailCategoryResponse> GetDetailCategory(GetDetailCategoryRequest request)
        {
            var category = await CategoryManager.FindAsync(request.Id) ?? throw new NotFoundException($"category with {request.Id} not found!!");
            var childCategories = await CategoryManager.GetAll()
                           .Where(x => x.CategoryEnums != CategoryEnums.Primary)
                           .ToListAsync();

            var response = Mapper.Map<GetDetailCategoryResponse>(category);
            response.Children = Mapper.Map<List<GetDetailCategoryResponse>>(GetChildren(category.Id, childCategories)) ?? new List<GetDetailCategoryResponse>();
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

        private static List<GetAllCategoriesResponseItem> BuildCategoryTree(List<Category> parents, List<Category> allChildren)
        {
            var categoryList = new List<GetAllCategoriesResponseItem>();

            foreach (var parent in parents)
            {
                var categoryItem = new GetAllCategoriesResponseItem
                {
                    Id = parent.Id,
                    Name = parent.Name,
                    Position = parent.Position,
                    ParentId = parent.ParentId,
                    CategoryEnums = parent.CategoryEnums,
                    Children = GetChildren(parent.Id, allChildren)
                };

                categoryList.Add(categoryItem);
            }

            return categoryList;
        }

        private static List<GetAllCategoriesResponseItem> GetChildren(Guid parentId, List<Category> allChildren)
        {
            var children = allChildren.Where(c => c.ParentId == parentId).ToList();
            var childItems = new List<GetAllCategoriesResponseItem>();

            foreach (var child in children)
            {
                var childItem = new GetAllCategoriesResponseItem
                {
                    Id = child.Id,
                    Name = child.Name,
                    Position = child.Position,
                    ParentId = child.ParentId,
                    CategoryEnums = child.CategoryEnums,
                    Children = GetChildren(child.Id, allChildren)
                };

                childItems.Add(childItem);
            }

            return childItems;
        }
    }
}