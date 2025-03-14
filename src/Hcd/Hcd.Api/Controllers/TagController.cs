using Hcd.Common.Exceptions;
using Hcd.Common.Requests.Management.Tag;
using Hcd.Data.Entities.Management;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/tags")]
    [Authorize]
    public class TagController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<ActionResult<List<Tag>>> GetAllTags([FromQuery] GetAllTagsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetDetailTag(Guid id)
        {
            var request = new GetDetailTagRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag([FromBody] CreateTagRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(Guid id, [FromBody] UpdateTagRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var request = new DeleteTagRequest { Id = id };
            await _mediator.Send(request);
            return Ok();
        }
    }
}