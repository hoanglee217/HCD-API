using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }
        public Guid BlogId { get; set; }
        public virtual required Blog Blog{ get; set; }
    }
}