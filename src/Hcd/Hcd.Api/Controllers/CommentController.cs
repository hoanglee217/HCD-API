using Hcd.Common.Exceptions;
using Hcd.Common.Requests.Comment;
using Hcd.Data.Entities.Management.Blog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CommentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAllComments(GetAllCommentsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetCommentById(Guid? id, GetDetailCommentRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Comment id not found!");
            }
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
        public async Task<IActionResult> UpdateComment(Guid? id, [FromBody] UpdateCommentRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Comment id not found!");
            }
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid? id, DeleteCommentRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Comment id not found!");
            }
            await _mediator.Send(request);
            return Ok();
        }
    }
}