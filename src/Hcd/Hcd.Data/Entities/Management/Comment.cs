using Hcd.Data.Entities.Authentication;
using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management
{
    public class Comment : BaseEntity
    {
        public required string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public virtual required User User{ get; set; }
        public virtual required Blog Blog{ get; set; }
    }
}