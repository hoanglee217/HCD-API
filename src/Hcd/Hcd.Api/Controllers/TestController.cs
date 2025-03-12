using Hcd.Data.Entities.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Hcd.Common.Requests.Authentication;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Hcd.Data;
using Hcd.Common;
using Microsoft.AspNetCore.Identity;
using Hcd.Common.Models;
using Hcd.Infrastructure.Authentication;
using System.Net;
using Hcd.Common.Interfaces.Abstractions;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController(
       ApplicationDbContext dbContext,
       IManagementRepository<User> userRepository
    ) : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IManagementRepository<User> _userRepository = userRepository;

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<RegisterResponse>>> GetBlogs(int pageNumber, int pageSize, string? search)
        {
            var offset = (pageNumber - 1) * pageSize;
            search ??= "";
            var searchString = "%" + search + "%"; // Ensure the search term is properly surrounded with % for LIKE
            var totalRecords = await _dbContext.Users
            .FromSqlRaw(@"SELECT COUNT(Id) FROM Users WHERE Email like {0}", searchString)
            .CountAsync();

            var users = await _dbContext.Users
            .FromSqlRaw(@"
                SELECT sql_no_cache pre.Id, FirstName, LastName, Email, PhoneNumber, Password, Role
                FROM (
                    SELECT sql_no_cache Id FROM Users
                    WHERE Email like {0}
                    ORDER BY LastName ASC, FirstName ASC
                ) AS temp
                INNER JOIN Users AS pre 
                ON temp.Id = pre.Id
                WHERE Email like {0}
                ORDER BY LastName ASC, FirstName ASC
                LIMIT {1} OFFSET {2}", searchString, pageSize, offset)
            .Select(u => new User
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
            })
            .ToListAsync();
            var response = users.Adapt<List<RegisterResponse>>();
            var result = new PaginationResponse<RegisterResponse>
            {
                Items = response,
                Meta = new PaginationMeta
                {
                    TotalItems = totalRecords,
                    Page = pageNumber,
                    PageSize = pageSize,
                    PageCount = (int)Math.Ceiling((double)totalRecords / pageSize)
                }
            };

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<List<RegisterResponse>>> SetLargeUser(List<RegisterRequest> requests)
        {
            var users = new List<User>();

            foreach (var request in requests)
            {
                // Generate a unique salt for each user
                byte[] salt = new byte[16];
                RandomNumberGenerator.Fill(salt);

                // Map RegisterRequest to User
                var newUser = request.Adapt<User>();
                newUser.Salt = salt;
                var passwordHandler = new PasswordHandler();
                newUser.Password = passwordHandler.HashPassword(request.Password, salt);

                users.Add(newUser);
            }

            // Add the list of users to the repository
            await _dbContext.Users.AddRangeAsync(users);
            await _dbContext.SaveChangesAsync();
            // Create response
            var responses = users.Adapt<List<RegisterResponse>>();

            return Ok(responses);
        }
    }
}