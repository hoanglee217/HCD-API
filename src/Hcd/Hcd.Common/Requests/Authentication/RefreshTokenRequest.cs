using MediatR;

namespace Hcd.Common.Requests.Authentication;

public class RefreshTokenRequest : IRequest<RefreshTokenResponse>
{
    public required string RefreshToken { get; set; }
};
public class RefreshTokenResponse
{
    public required string AccessToken { get; set; }
};