using MediatR;

namespace Hcd.Common.Requests.Token;

public class GeneratorTokenPayload
{
    public required Guid UserId { get; set; }
    public required string Email { get; set; }
};
