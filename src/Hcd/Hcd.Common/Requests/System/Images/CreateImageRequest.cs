using MediatR;

namespace Hcd.Common.Requests.System.Images;

public class CreateImageRequest : IRequest<CreateImageResponse>
{
    public required string Name { get; set; }
}

public class CreateImageResponse
{
    public required string Name { get; set; }
}
