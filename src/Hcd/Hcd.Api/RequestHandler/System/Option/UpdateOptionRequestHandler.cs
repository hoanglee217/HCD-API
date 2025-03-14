using Hcd.Application.Services.System;
using Hcd.Common.Requests.System.Option;
using MediatR;

namespace Hcd.Api.RequestHandler.System.Option;

public class UpdateOptionRequestHandler(OptionService OptionService) : IRequestHandler<UpdateOptionRequest, UpdateOptionResponse>
{
    public Task<UpdateOptionResponse> Handle(UpdateOptionRequest request, CancellationToken cancellationToken)
    {
        return OptionService.UpdateOption(request);
    }
}