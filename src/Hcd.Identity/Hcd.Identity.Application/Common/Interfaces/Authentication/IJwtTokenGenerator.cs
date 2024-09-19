namespace Hcd.Identity.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GeneratorToken(Guid userId, string email, string firstName, string lastName);
    }
}