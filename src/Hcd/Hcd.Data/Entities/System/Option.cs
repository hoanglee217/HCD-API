using Hcd.Data.Models;

namespace Hcd.Data.Entities.System
{
    public class Option : BaseEntity
    {
        public required string Name { get; set; }
        public string? Value { get; set; }
        
    }
}