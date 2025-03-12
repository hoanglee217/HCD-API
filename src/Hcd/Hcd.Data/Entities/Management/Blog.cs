using Hcd.Data.Entities.Authentication;
using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management
{
    public class Blog : BaseEntity
    {
        public required string Title { get; set; }
        public string? Content { get; set; }
        public string? Thumbnail { get; set; }
        public int? Rating { get; set; }
        public string? Slug { get; set; }
        public required Guid UserId { get; set; }
        public virtual required User User { get; set; }
        public virtual List<BlogCategory> BlogCategories { get; set; } = new();

    }
}