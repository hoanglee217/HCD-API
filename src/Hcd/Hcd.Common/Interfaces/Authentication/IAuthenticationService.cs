using Hcd.Common.Requests.Authentication;

namespace Hcd.Common.Interface.Authentication
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken);
        Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken);
        Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request, CancellationToken cancellationToken);
    }
}