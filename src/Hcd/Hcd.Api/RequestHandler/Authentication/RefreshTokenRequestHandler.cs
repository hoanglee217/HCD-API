using Hcd.Application.Services.Authentication;
using Hcd.Common.Requests.Authentication;
using Hcd.Common.Interface.Authentication;
using MediatR;

namespace Hcd.Api.RequestHandler.Authentication
{
    public class RefreshTokenRequestHandler(IAuthenticationService authenticationService) : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
    {
        public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            return await authenticationService.RefreshToken(request, cancellationToken);
        }
    }
}