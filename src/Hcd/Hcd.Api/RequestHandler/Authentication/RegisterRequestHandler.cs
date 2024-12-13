using Hcd.Application.Services.Authentication;
using Hcd.Common.Requests.Authentication;
using Hcd.Common.Interfaces.Authentication;
using MediatR;

namespace Hcd.Api.RequestHandler.Authentication
{
    public class RegisterRequestHandler(AuthenticationService authenticationService) : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        public Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            return  authenticationService.Register(request);
        }
    }
}