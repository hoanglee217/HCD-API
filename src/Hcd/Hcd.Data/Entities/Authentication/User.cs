
using Hcd.Common.Enums;
using Hcd.Data.Entities.Management.Blog;
using Hcd.Data.Models;

namespace Hcd.Data.Entities.Authentication
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Password { get; set; }
        public byte[]? Salt { get; set; }
        public UserRoleEnums Role { get; set; } = UserRoleEnums.Guest;
        public virtual ICollection<Blog>? Blogs{ get; set; }

    }
}