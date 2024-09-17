using Hcd.Identity.Data.Entities.Authentication;
using MediatR;

namespace Hcd.Identity.Contracts.Requests.Authentication;
public record LoginRequest
(
    string Email,
    string Password
)  : IRequest<LoginResponse>;
public record LoginResponse
(
    User User,
    string Token
);