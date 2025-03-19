using Hcd.Common.Requests.System.Images;
using Hcd.Application.Services.System;
using MediatR;

namespace Hcd.Api.RequestHandler.System.Images;

public class UpdateImageHandler(ImageService imageService) : IRequestHandler<UpdateImageRequest, UpdateImageResponse>
{
    public Task<UpdateImageResponse> Handle(UpdateImageRequest request, CancellationToken cancellationToken)
    {
        return imageService.UpdateImage(request);
    }
}