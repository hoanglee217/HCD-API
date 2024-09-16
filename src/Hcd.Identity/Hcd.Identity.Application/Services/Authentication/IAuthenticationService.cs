using Hcd.Identity.Contracts.Authentication;

namespace Hcd.Identity.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        RegisterResponse Register(RegisterRequest request);
        LoginResponse Login(LoginRequest request);
    }
}