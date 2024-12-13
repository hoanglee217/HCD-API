using System.Security.Claims;
using Hcd.Common.Exceptions;
using Hcd.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Hcd.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentUserId()
        {
            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(userIdString, out Guid userId))
            {
                return userId;
            }

            return Guid.Empty;
        }

        public string GetCurrentUserName()
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            return userName ?? throw new NotFoundException("User doesn't exist");
        }
    }
}