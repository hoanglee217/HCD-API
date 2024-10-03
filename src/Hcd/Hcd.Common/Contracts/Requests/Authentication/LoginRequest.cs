using MediatR;

namespace Hcd.Common.Contracts.Requests.Authentication;
public record LoginRequest
(
    string Email,
    string Password
)  : IRequest<LoginResponse>;
public record LoginResponse
(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);