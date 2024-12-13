using MediatR;

namespace Hcd.Common.Requests.Authentication;
public class LoginRequest : IRequest<LoginResponse>
{
    public required string Email { get; set;}
    public required string Password { get; set;}
    public bool? RememberMe { get; set;}
};
public class LoginResponse
{
    public required Guid Id { get; set;}
    public string? FirstName { get; set;}
    public string? LastName { get; set;}
    public required string Email { get; set;}
    public required string AccessToken { get; set;}
    public required string RefreshToken { get; set;}
};