using MediatR;

namespace Hcd.Common.Contracts.Requests.Authentication;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password
) : IRequest<RegisterResponse>;
public record RegisterResponse
(
    Guid Id,
    string FirstName,
    string LastName,
    string Email
);