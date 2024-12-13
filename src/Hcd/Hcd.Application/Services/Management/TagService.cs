using Hcd.Application.Manages.Management;
using Hcd.Common.Exceptions;
using Hcd.Common.Models;
using Hcd.Common.Requests.Tag;
using Hcd.Data.Entities.Management.Blog;
using Hcd.Data.Instances;

namespace Hcd.Application.Services.Management
{
    public class TagService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
    {
        private TagManager TagManager => GetService<TagManager>();

        public async Task<GetAllTagsResponse> GetAllTags(GetAllTagsRequest request)
        {
            var tag = TagManager.GetAll(request.Search, request.Filter);
            var paginationResponse = await PaginationResponse<Tag>.Create(
                tag,
                request
            );

            return Mapper.Map<GetAllTagsResponse>(paginationResponse);
        }

        public async Task<GetDetailTagResponse> GetDetailTag(GetDetailTagRequest request)
        {
            var tag = await TagManager.FindAsync(request.Id) ?? throw new NotFoundException($"tag with {request.Id} not found!!");

            var response = Mapper.Map<GetDetailTagResponse>(tag);
            return response;
        }

        public async Task<CreateTagResponse> CreateTag(CreateTagRequest request)
        {
            var newTag = request.Adapt<Tag>();
            await TagManager.AddAsync(newTag);
            await UnitOfWork.SaveChangesAsync();
            var response = Mapper.Map<CreateTagResponse>(newTag);
            return response;
        }

        public async Task DeleteTag(DeleteTagRequest request)
        {
            TagManager.Delete(request.Id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<UpdateTagResponse> UpdateTag(UpdateTagRequest request)
        {
            var tag = await TagManager.FindAsync(request.Id) ?? throw new NotFoundException($"tag with {request.Id} not found!!");
            var updatedTag = request.Adapt(tag);

            await TagManager.Update(tag);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<UpdateTagResponse>(updatedTag);
        }
    }
}