using MediatR;

namespace Hcd.Common.Requests.System.Images;

public class CreateImageRequest : IRequest<CreateImageResponse>
{
    public required string Url { get; set; }
    public string? FileName { get; set; }
    public string? AltText { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? Title { get; set; }
    public string? Caption { get; set; }
    public string? Description { get; set; }
}

public class CreateImageResponse
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
