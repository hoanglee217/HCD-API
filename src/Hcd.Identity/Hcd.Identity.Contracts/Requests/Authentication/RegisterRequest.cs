using Hcd.Identity.Data.Entities.Authentication;

namespace Hcd.Identity.Contracts.Authentication;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    string PasswordConfirmed
);
public record RegisterResponse(
    User User
);