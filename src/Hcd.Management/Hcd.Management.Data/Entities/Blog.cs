using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hcd.Management.Data.Entities
{
    public class Blog
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Content { get; set; } 
    }
}