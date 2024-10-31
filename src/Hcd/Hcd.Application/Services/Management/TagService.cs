using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Tag;
using Hcd.Data.Entities.Management.Blog;
using Mapster;
using MapsterMapper;

namespace Hcd.Application.Services.Management
{
    public class TagService(
        IRepository<Tag> categoryRepository,
        IMapper mapper
    ) : ITagService
    {
        private readonly IRepository<Tag> _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<CreateTagResponse> CreateTag(CreateTagRequest request, CancellationToken cancellationToken)
        {
            var newTag = request.Adapt<Tag>();
            await _categoryRepository.AddAsync(newTag);
            var response = _mapper.Map<CreateTagResponse>(newTag);
            return response;
        }

        public async Task DeleteTag(DeleteTagRequest request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(request.Id);
        }

        public async Task<List<GetAllTagsResponse>> GetAllTags(GetAllTagsRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAllAsync();
            var response = _mapper.Map<List<GetAllTagsResponse>>(category);
            return response;
        }

        public async Task<GetDetailTagResponse> GetDetailTag(GetDetailTagRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            var response = _mapper.Map<GetDetailTagResponse>(category);
            return response;
        }

        public async Task<UpdateTagResponse> UpdateTag(UpdateTagRequest request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Tag>();
            await _categoryRepository.UpdateAsync(category);
            var response = _mapper.Map<UpdateTagResponse>(category);
            return response;
        }
    }
}