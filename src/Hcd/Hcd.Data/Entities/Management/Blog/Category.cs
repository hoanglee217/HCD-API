using Hcd.Common.Enums;
using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management.Blog
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public int Position { get; set; }
        public Guid? ParentId { get; set; }
        public CategoryEnums CategoryEnums { get; set; } 
        public required Guid BlogId { get; set; }
        public virtual required Blog Blog{ get; set; }
    }
}