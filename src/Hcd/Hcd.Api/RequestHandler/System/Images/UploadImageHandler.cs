using Hcd.Common.Requests.System.Images;
using Hcd.Application.Services.System;
using MediatR;

namespace Hcd.Api.RequestHandler.System.Images;

public class UploadImageHandler(ImageService imageService) : IRequestHandler<UploadImageRequest, UploadImageResponse>
{
    public Task<UploadImageResponse> Handle(UploadImageRequest request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File.Length == 0)
        {
            throw new ArgumentException("File is required.");
        }

        return imageService.UploadImage(request.File);
    }
}