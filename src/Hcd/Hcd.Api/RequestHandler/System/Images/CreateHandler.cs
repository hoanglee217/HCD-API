using Hcd.Common.Requests.System.Images;
using Hcd.Application.Services.System;
using MediatR;

namespace Hcd.Api.RequestHandler.System.Images;

public class CreateImageHandler(ImageService imageService) : IRequestHandler<CreateImageRequest, CreateImageResponse>
{
    public Task<CreateImageResponse> Handle(CreateImageRequest request, CancellationToken cancellationToken)
    {
        return imageService.CreateImage(request);
    }
}