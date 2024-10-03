
using Hcd.Common.Enums;
using Hcd.Data.Models;

namespace Hcd.Data.Entities.Authentication
{
    public class User : BaseEntity
    {
        public required Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Password { get; set; }
        public string? Country { get; set; }
        public string? Cty { get; set; }
        public string? State { get; set; }
        public byte[]? Salt { get; set; }
        public UserRoleEnums Role { get; set; }
    }
}