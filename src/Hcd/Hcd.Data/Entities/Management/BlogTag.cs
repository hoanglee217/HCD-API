using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management;

public class BlogTag : BaseEntity
{
    public required Guid BlogId { get; set; }
    public required Guid TagId { get; set; }
    public virtual required Blog Blog { get; set; }
    public virtual required Tag Tag { get; set; }
}
