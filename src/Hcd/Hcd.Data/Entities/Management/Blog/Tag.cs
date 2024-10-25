using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management.Blog
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }
        public Guid PostId { get; set; }
        public virtual required Blog Blog{ get; set; }
    }
}