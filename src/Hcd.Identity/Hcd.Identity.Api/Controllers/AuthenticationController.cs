using Hcd.Identity.Application.Services.Authentication;
using Hcd.Identity.Contracts.Requests.Authentication;
using Hcd.Identity.Data.Entities.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Identity.Api.Controllers
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
    }
}