using MediatR;
using Microsoft.AspNetCore.Mvc;
using Hcd.Common.Requests.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}