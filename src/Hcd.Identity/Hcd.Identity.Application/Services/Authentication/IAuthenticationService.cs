using Hcd.Identity.Contracts.Requests.Authentication;

namespace Hcd.Identity.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken);
        Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken);
    }
}