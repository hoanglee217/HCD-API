using Hcd.Identity.Application.Services.Authentication;
using Hcd.Identity.Contracts.Requests.Authentication;
using MediatR;

namespace Hcd.Identity.Api.RequestHandler.Authentication
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterRequestHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            return await _authenticationService.Register(request, cancellationToken);
        }
    }
}