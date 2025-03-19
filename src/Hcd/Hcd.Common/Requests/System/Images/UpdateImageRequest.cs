using MediatR;

namespace Hcd.Common.Requests.System.Images;

public class UpdateImageRequest : IRequest<UpdateImageResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class UpdateImageResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
