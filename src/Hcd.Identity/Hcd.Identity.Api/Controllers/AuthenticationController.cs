using Hcd.Identity.Application.Services.Authentication;
using Hcd.Identity.Contracts.Authentication;
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
            var authResult = _authentication.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.PhoneNumber,
                request.Password
            );

            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.PhoneNumber,
                authResult.Token
            );
            return Ok(response);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authentication.Login(
                request.Email,
                request.Password
            );

            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.PhoneNumber,
                authResult.Token
            );
            return Ok(response);
        }
    }
}