using MediatR;

namespace Hcd.Common.Requests.System.Images;

public class GetDetailImageRequest : IRequest<GetDetailImageResponse>
{
    public required Guid Id { get; set; }
}

public class GetDetailImageResponse
{
    public Guid Id { get; set; }
    public required string Url { get; set; }
    public string? FileName { get; set; }
    public string? AltText { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? Title { get; set; }
    public string? Caption { get; set; }
    public string? Description { get; set; }
}
