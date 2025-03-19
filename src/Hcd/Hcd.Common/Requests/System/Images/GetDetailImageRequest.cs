using MediatR;

namespace Hcd.Common.Requests.System.Images;

public class GetDetailImageRequest : IRequest<GetDetailImageResponse>
{
    public required Guid Id { get; set; }
}

public class GetDetailImageResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
