using Hcd.Common.Requests.Category;

namespace Hcd.Common.Interfaces.Management
{
    public interface ICategoryService
    {
        Task<List<GetAllCategoriesResponse>> GetAllCategories(GetAllCategoriesRequest request, CancellationToken cancellationToken);
        Task<GetDetailCategoryResponse> GetDetailCategory(GetDetailCategoryRequest request, CancellationToken cancellationToken);
        Task<CreateCategoryResponse> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken);
        Task<UpdateCategoryResponse> UpdateCategory(UpdateCategoryRequest request, CancellationToken cancellationToken);
        Task DeleteCategory(DeleteCategoryRequest request, CancellationToken cancellationToken);
    }
}