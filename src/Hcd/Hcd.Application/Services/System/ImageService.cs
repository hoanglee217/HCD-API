using Hcd.Common.Models;
using Hcd.Data.Instances;
using Hcd.Common.Exceptions;
using Hcd.Common.Requests.System.Images;
using Hcd.Application.Managers.System;
using Hcd.Data.Entities.System;

namespace Hcd.Application.Services.System;

public class ImageService(IServiceProvider serviceProvider) : ApplicationService(serviceProvider)
{
    private ImageManager ImageManager => GetService<ImageManager>();
    
    public async Task<GetAllImagesResponse> GetAllImages(GetAllImagesRequest request)
    {
        var images = ImageManager.GetAll();

        var paginationResponse = await PaginationResponse<Image>.Create(
            images,
            request
        );

        return Mapper.Map<GetAllImagesResponse>(paginationResponse);
    }

    public async Task<GetDetailImageResponse> GetDetailImage(GetDetailImageRequest request)
    {
        var image = await ImageManager.FindAsync(request.Id);

        if (image == null)
        {
            throw new NotFoundException($"image with {request.Id} not found!!");
        }

        return Mapper.Map<GetDetailImageResponse>(image);
    }

    public async Task<CreateImageResponse> CreateImage(CreateImageRequest request)
    {
        var image = Mapper.Map<Image>(request);

        await ImageManager.AddAsync(image);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<CreateImageResponse>(image);
    }

    public async Task<UpdateImageResponse> UpdateImage(UpdateImageRequest request)
    {
        var image = await ImageManager.FirstOrDefaultAsync(o => o.Id == request.Id);

        if(image == null)
        {
            throw new NotFoundException($"image with {request.Id} not found!!");
        }

        // TODO: Update image properties

        var updatedImage = ImageManager.Update(image);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<UpdateImageResponse>(updatedImage);
    }

    public async Task DeleteImage(DeleteImageRequest request)
    {
        ImageManager.Delete(request.Id);

        await UnitOfWork.SaveChangesAsync();
    }
}
