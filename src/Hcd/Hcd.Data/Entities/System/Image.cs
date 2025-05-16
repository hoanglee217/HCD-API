using Hcd.Data.Models;

namespace Hcd.Data.Entities.System;

public class Image : BaseEntity
{
    public required string Url { get; set; }
    public string? FileName { get; set; }
    public string? AltText { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? Title { get; set; }
    public string? Caption { get; set; }
    public string? Description { get; set; }
    public long? Size { get; set; }
    public string? Format { get; set; }
}
