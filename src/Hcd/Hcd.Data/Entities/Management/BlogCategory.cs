using Hcd.Data.Entities.Authentication;
using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management
{
    public class BlogCategory : BaseEntity
    {
        public required Guid BlogId { get; set; }
        public required Guid CategoryId { get; set; }
        public virtual required Blog Blog { get; set; }
        public virtual required Category Category { get; set; }
    }
}