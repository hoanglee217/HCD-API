using Hcd.Common.Requests.System.Images;
using Hcd.Application.Services.System;
using MediatR;

namespace Hcd.Api.RequestHandler.System.Images;

public class GetAllImagesHandler(ImageService imageService) : IRequestHandler<GetAllImagesRequest, GetAllImagesResponse>
{
    public Task<GetAllImagesResponse> Handle(GetAllImagesRequest request, CancellationToken cancellationToken)
    {
        return imageService.GetAllImages(request);
    }
}
