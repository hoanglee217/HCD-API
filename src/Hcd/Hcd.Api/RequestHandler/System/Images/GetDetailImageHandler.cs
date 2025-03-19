using Hcd.Common.Requests.System.Images;
using Hcd.Application.Services.System;
using MediatR;

namespace Hcd.Api.RequestHandler.System.Images;

public class GetDetailImageHandler(ImageService imageService) : IRequestHandler<GetDetailImageRequest, GetDetailImageResponse>
{
    public Task<GetDetailImageResponse> Handle(GetDetailImageRequest request, CancellationToken cancellationToken)
    {
        return imageService.GetDetailImage(request);
    }
}
