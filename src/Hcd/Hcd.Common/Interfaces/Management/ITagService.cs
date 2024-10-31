using Hcd.Common.Requests.Tag;

namespace Hcd.Common.Interfaces.Management
{
    public interface ITagService
    {
        Task<List<GetAllTagsResponse>> GetAllTags(GetAllTagsRequest request, CancellationToken cancellationToken);
        Task<GetDetailTagResponse> GetDetailTag(GetDetailTagRequest request, CancellationToken cancellationToken);
        Task<CreateTagResponse> CreateTag(CreateTagRequest request, CancellationToken cancellationToken);
        Task<UpdateTagResponse> UpdateTag(UpdateTagRequest request, CancellationToken cancellationToken);
        Task DeleteTag(DeleteTagRequest request, CancellationToken cancellationToken);
    }
}