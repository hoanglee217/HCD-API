using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Category;
using Hcd.Data.Entities.Management.Blog;
using Mapster;
using MapsterMapper;

namespace Hcd.Application.Services.Management
{
    public class CategoryService(
        IRepository<Category> categoryRepository,
        IMapper mapper
    ) : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetAllCategoriesResponse>> GetAllCategories(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAllAsync();
            var response = _mapper.Map<List<GetAllCategoriesResponse>>(category);
            return response;
        }

        public async Task<GetDetailCategoryResponse> GetDetailCategory(GetDetailCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            var response = _mapper.Map<GetDetailCategoryResponse>(category);
            return response;
        }

        public async Task<CreateCategoryResponse> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var newCategory = request.Adapt<Category>();
            await _categoryRepository.AddAsync(newCategory);
            var response = _mapper.Map<CreateCategoryResponse>(newCategory);
            return response;
        }

        public async Task DeleteCategory(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(request.Id);
        }

        public async Task<UpdateCategoryResponse> UpdateCategory(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Category>();
            await _categoryRepository.UpdateAsync(category);
            var response = _mapper.Map<UpdateCategoryResponse>(category);
            return response;
        }
    }
}