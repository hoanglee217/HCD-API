using Hcd.Application.Services.Authentication;
using Hcd.Common.Contracts.Requests.Authentication;
using Hcd.Common.Interface.Authentication;
using MediatR;

namespace Hcd.Api.RequestHandler.Authentication
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