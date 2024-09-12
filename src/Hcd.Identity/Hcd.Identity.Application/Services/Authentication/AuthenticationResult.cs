namespace Hcd.Identity.Application.Services.Authentication;
    public record AuthenticationResult
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Token
    );
