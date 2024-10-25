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
        public Task<CreateCategoryResponse> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var newCategory = request.Adapt<Category>();
            _categoryRepository.Add(newCategory);
            var response = _mapper.Map<CreateCategoryResponse>(newCategory);
            return Task.FromResult(response);
        }

        public Task DeleteCategory(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            _categoryRepository.Delete(request.Id);
            throw new NotImplementedException();
        }

        public Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetAll();
            var response = _mapper.Map<GetAllCategoriesResponse>(category);
            return Task.FromResult(response);
        }

        public Task<GetDetailCategoryResponse> GetDetailCategory(GetDetailCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(request.Id);
            var response = _mapper.Map<GetDetailCategoryResponse>(category);
            return Task.FromResult(response);
        }

        public Task<UpdateCategoryResponse> UpdateCategory(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            
            var category = request.Adapt<Category>();
            _categoryRepository.Update(category);
            var response = _mapper.Map<UpdateCategoryResponse>(category);
            return Task.FromResult(response);
        }
    }
}