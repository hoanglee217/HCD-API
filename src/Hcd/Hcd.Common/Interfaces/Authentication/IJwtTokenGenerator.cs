using System.Security.Claims;
using Hcd.Common.Requests.Token;

namespace Hcd.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GeneratorToken(GeneratorTokenPayload payload, string signingCredentials, int expiration);
        ClaimsPrincipal VerifyRefreshToken(string token);
    }
}