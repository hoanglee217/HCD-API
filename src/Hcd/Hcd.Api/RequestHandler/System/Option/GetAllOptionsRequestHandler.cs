using Hcd.Application.Services.System;
using Hcd.Common.Requests.System.Option;
using MediatR;

namespace Hcd.Api.RequestHandler.System.Option;

public class GetAllOptionsRequestHandler(OptionService OptionService) : IRequestHandler<GetAllOptionsRequest, GetAllOptionsResponse>
{
    public Task<GetAllOptionsResponse> Handle(GetAllOptionsRequest request, CancellationToken cancellationToken)
    {
        return OptionService.GetAllOptions(request);
    }
}