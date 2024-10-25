using MediatR;

namespace Hcd.Common.Requests.Authentication;

public class RegisterRequest : IRequest<RegisterResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public required string Password { get; set; }
};
public class RegisterResponse
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
};