using System.Net;

namespace Hcd.Identity.Contracts.Authentication;
public record LoginRequest
(
    string Email,
    string Password
);