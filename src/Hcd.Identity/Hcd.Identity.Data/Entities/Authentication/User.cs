
using Hcd.Shared.Common.Enums;

namespace Hcd.Identity.Data.Entities.Authentication
{
    public class User
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
        public UserRoleEnums Role { get; set; }
    }
}