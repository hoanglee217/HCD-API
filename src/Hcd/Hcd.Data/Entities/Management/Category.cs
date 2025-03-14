using Hcd.Common.Enums;
using Hcd.Data.Models;

namespace Hcd.Data.Entities.Management
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public int Position { get; set; }
        public Guid? ParentId { get; set; }
        public CategoryEnums CategoryEnums { get; set; }
        public virtual ICollection<BlogCategory> BlogCategories { get; set; } = new List<BlogCategory>();
    }
}