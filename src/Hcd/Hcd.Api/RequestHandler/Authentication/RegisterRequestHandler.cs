using Hcd.Application.Services.Authentication;
using Hcd.Common.Contracts.Requests.Authentication;
using Hcd.Common.Interface.Authentication;
using MediatR;

namespace Hcd.Api.RequestHandler.Authentication
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