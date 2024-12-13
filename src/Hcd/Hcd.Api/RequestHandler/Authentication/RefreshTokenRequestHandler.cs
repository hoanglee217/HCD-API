using Hcd.Application.Services.Authentication;
using Hcd.Common.Requests.Authentication;
using Hcd.Common.Interfaces.Authentication;
using MediatR;

namespace Hcd.Api.RequestHandler.Authentication
{
    public class RefreshTokenRequestHandler(AuthenticationService authenticationService) : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
    {
        public Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken = default)
        {
            return authenticationService.RefreshToken(request);
        }
    }
}