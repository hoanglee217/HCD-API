using Hcd.Common.Models;
using Hcd.Data.Instances;
using Hcd.Common.Exceptions;
using Hcd.Common.Requests.Management.BlogTag;
using Hcd.Application.Managers.Management;
using Hcd.Data.Entities.Management;

namespace Hcd.Application.Services.Management;

public class BlogTagService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
{
    private BlogTagManager BlogTagManager => GetService<BlogTagManager>();
    
    public async Task<GetAllBlogTagsResponse> GetAllBlogTags(GetAllBlogTagsRequest request)
    {
        var blogTags = BlogTagManager.GetAll();

        var paginationResponse = await PaginationResponse<BlogTag>.Create(
            blogTags,
            request
        );

        return Mapper.Map<GetAllBlogTagsResponse>(paginationResponse);
    }

    public async Task<GetDetailBlogTagResponse> GetDetailBlogTag(GetDetailBlogTagRequest request)
    {
        var blogTag = await BlogTagManager.FindAsync(request.Id);

        if (blogTag == null)
        {
            throw new NotFoundException($"blogTag with {request.Id} not found!!");
        }

        return Mapper.Map<GetDetailBlogTagResponse>(blogTag);
    }

    public async Task<CreateBlogTagResponse> CreateBlogTag(CreateBlogTagRequest request)
    {
        var blogTag = Mapper.Map<BlogTag>(request);

        await BlogTagManager.AddAsync(blogTag);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<CreateBlogTagResponse>(blogTag);
    }

    public async Task<UpdateBlogTagResponse> UpdateBlogTag(UpdateBlogTagRequest request)
    {
        var blogTag = await BlogTagManager.FirstOrDefaultAsync(o => o.Id == request.Id);

        if(blogTag == null)
        {
            throw new NotFoundException($"blogTag with {request.Id} not found!!");
        }

        // TODO: Update blogTag properties

        var updatedBlogTag = BlogTagManager.Update(blogTag);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<UpdateBlogTagResponse>(updatedBlogTag);
    }

    public async Task DeleteBlogTag(DeleteBlogTagRequest request)
    {
        BlogTagManager.Delete(request.Id);

        await UnitOfWork.SaveChangesAsync();
    }
}
