using Hcd.Common.Requests.Authentication;
using MediatR;
using Hcd.Application.Services.Authentication;

namespace Hcd.Api.RequestHandler.Authentication
{
    public class LoginRequestHandler(AuthenticationService authenticationService) : IRequestHandler<LoginRequest, LoginResponse>
    {
        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            return authenticationService.Login(request);
        }
    }
}