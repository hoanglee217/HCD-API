using Microsoft.AspNetCore.Mvc;

namespace Hcd.Shared.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExceptionHandlerController : ControllerBase
    {
        [HttpGet("NoException")]
        public ActionResult NoException()
        {
            return Ok(".net real world example");
        }

        [HttpGet("NotImplementedException")]
        public ActionResult GetNotImplementedException()
        {
            throw new NotImplementedException();
        }

        [HttpGet("TimeoutException")]
        public ActionResult GetTimeoutException()
        {
            throw new TimeoutException();
        }

    }
}