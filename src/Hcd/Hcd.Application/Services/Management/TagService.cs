using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Management;
using Hcd.Common.Requests.Tag;
using Hcd.Data.Entities.Management.Blog;
using Mapster;
using MapsterMapper;

namespace Hcd.Application.Services.Management
{
    public class TagService(
        IRepository<Tag> tagRepository,
        IMapper mapper
    ) : ITagService
    {
        private readonly IRepository<Tag> _tagRepository = tagRepository;
        private readonly IMapper _mapper = mapper;
        public Task<CreateTagResponse> CreateTag(CreateTagRequest request, CancellationToken cancellationToken)
        {
            var newTag = request.Adapt<Tag>();
            _tagRepository.Add(newTag);
            var response = _mapper.Map<CreateTagResponse>(newTag);
            return Task.FromResult(response);
        }

        public Task DeleteTag(DeleteTagRequest request, CancellationToken cancellationToken)
        {
            _tagRepository.Delete(request.Id);
            throw new NotImplementedException();
        }

        public Task<GetAllTagsResponse> GetAllTags(GetAllTagsRequest request, CancellationToken cancellationToken)
        {
            var tag = _tagRepository.GetAll();
            var response = _mapper.Map<GetAllTagsResponse>(tag);
            return Task.FromResult(response);
        }

        public Task<GetDetailTagResponse> GetDetailTag(GetDetailTagRequest request, CancellationToken cancellationToken)
        {
            var tag = _tagRepository.GetById(request.Id);
            var response = _mapper.Map<GetDetailTagResponse>(tag);
            return Task.FromResult(response);
        }

        public Task<UpdateTagResponse> UpdateTag(UpdateTagRequest request, CancellationToken cancellationToken)
        {
            
            var tag = request.Adapt<Tag>();
            _tagRepository.Update(tag);
            var response = _mapper.Map<UpdateTagResponse>(tag);
            return Task.FromResult(response);
        }
    }
}