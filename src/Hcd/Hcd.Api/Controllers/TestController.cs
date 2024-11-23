using Hcd.Data.Entities.Authentication;
using Hcd.Common.Enums;
using Hcd.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetBlogs()
        {
            var blogs = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = EnvGlobal.ConnectionString,
                    LastName = EnvGlobal.JwtAudience,
                    Email = "john.doe@example.com",
                    PhoneNumber = "+1234567890",
                    Password = "password123",
                    Country = "USA",
                    Cty = "New York",
                    State = "NY",
                    Role = UserRoleEnums.Administrator
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "+0987654321",
                    Password = "password123",
                    Country = "Canada",
                    Cty = "Toronto",
                    State = "Ontario",
                    Role = UserRoleEnums.Customer
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex",
                    LastName = "Johnson",
                    Email = "alex.johnson@example.com",
                    PhoneNumber = "+1230984567",
                    Password = "securePassword!",
                    Country = "UK",
                    Cty = "London",
                    State = "England",
                    Role = UserRoleEnums.Guest
                }
            };

            return Ok(blogs);
        }
    }
}