using Hcd.Common.Exceptions;
using Hcd.Common.Requests.Management.Comment;
using Hcd.Data.Entities.Management;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/comments")]
    [Authorize]
    public class CommentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments([FromQuery] GetAllCommentsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetDetailComment(Guid id)
        {
            var request = new GetDetailCommentRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment([FromBody] CreateCommentRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] UpdateCommentRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var request = new DeleteCommentRequest { Id = id };
            await _mediator.Send(request);
            return Ok();
        }
    }
}