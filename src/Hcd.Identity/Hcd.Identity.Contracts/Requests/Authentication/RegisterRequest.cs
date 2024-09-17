using Hcd.Identity.Data.Entities.Authentication;
using MediatR;

namespace Hcd.Identity.Contracts.Requests.Authentication;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    string PasswordConfirmed
) : IRequest<RegisterResponse>;
public record RegisterResponse
(
    User User
);