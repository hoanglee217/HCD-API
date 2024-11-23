using Hcd.Data.Entities.Authentication;
using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management.Blog
{
    public class Blog : BaseEntity
    {
        public required string Title { get; set; }
        public string? Content { get; set; }
        public string? Thumbnail { get; set; }
        public int? Rating { get; set; }
        public string? Slug { get; set; }
        public required Guid UserId { get; set; }
        public required Guid CategoryId { get; set; }
        public virtual required User User{ get; set; }
        public virtual required Category Category{ get; set; }
    }
}