using Hcd.Identity.Data.Entities.Authentication;

namespace Hcd.Identity.Contracts.Authentication;
public record LoginRequest
(
    string Email,
    string Password
);
public record LoginResponse
(
    User User,
    string Token
);