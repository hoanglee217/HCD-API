using Hcd.Common.Exceptions;
using Hcd.Common.Requests.Tag;
using Hcd.Data.Entities.Management.Blog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TagController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags(GetAllTagsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTagById(Guid? id, GetDetailTagRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Tag id not found!");
            }
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag(CreateTagRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(Guid? id, [FromBody] UpdateTagRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Tag id not found!");
            }
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid? id, DeleteTagRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Tag id not found!");
            }
            await _mediator.Send(request);
            return Ok();
        }
    }
}