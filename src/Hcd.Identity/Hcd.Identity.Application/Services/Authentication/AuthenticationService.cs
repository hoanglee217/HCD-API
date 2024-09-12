using Hcd.Identity.Application.Common.Interfaces.Authentication;
using Hcd.Identity.Contracts.Authentication;

namespace Hcd.Identity.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string phoneNumber, string password)
        {

            return new AuthenticationResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                phoneNumber,
                "Token"
            );
        }

        public AuthenticationResult Login(string email, string password)
        {
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GeneratorToken(userId, email);

            return new AuthenticationResult(
                Guid.NewGuid(),
                "FirstName",
                "LastName",
                email,
                "PhoneNumber",
                token
            );
        }
    }
}