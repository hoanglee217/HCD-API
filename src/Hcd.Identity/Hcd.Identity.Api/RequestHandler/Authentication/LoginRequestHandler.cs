using Hcd.Identity.Application.Services.Authentication;
using Hcd.Identity.Contracts.Requests.Authentication;
using MediatR;

namespace Hcd.Identity.Api.RequestHandler.Authentication
{
    public class LoginRequestHandler(IAuthenticationService authentication) : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IAuthenticationService _authentication = authentication;
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            return await _authentication.Login(request, cancellationToken);
        }
    }
}