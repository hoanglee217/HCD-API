using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();

    }
}