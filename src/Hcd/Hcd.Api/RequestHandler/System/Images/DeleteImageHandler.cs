using Hcd.Common.Requests.System.Images;
using Hcd.Application.Services.System;
using MediatR;

namespace Hcd.Api.RequestHandler.System.Images;

public class DeleteImageHandler(ImageService imageService) : IRequestHandler<DeleteImageRequest>
{
    public Task Handle(DeleteImageRequest request, CancellationToken cancellationToken)
    {
        return imageService.DeleteImage(request);
    }
}
