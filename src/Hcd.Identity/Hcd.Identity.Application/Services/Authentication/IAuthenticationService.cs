namespace Hcd.Identity.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(string firstName, string lastName, string email, string phoneNumber, string password);
        AuthenticationResult Login(string email, string password);
    }
}