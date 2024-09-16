using Hcd.Identity.Application.Services.Authentication;
using Hcd.Identity.Contracts.Authentication;
using Hcd.Identity.Data.Entities.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Identity.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;

        public AuthenticationController(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authentication.Register(request);

            var response = new RegisterResponse(
                authResult.User
            );

            return Ok(response);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authentication.Login(request);

            var response = new LoginResponse(
                authResult.User,
                authResult.Token
            );
            return Ok(response);
        }
    }
}