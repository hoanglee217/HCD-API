using Hcd.Common.Requests.Blog;
using Hcd.Data.Entities.Management.Blog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    [Authorize]
    public class BlogController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<ActionResult<List<Blog>>> GetAllBlogs([FromQuery] GetAllBlogsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET: api/Blogs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetDetailBlog(Guid id)
        {
            var request = new GetDetailBlogsRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // POST: api/Blogs
        [HttpPost]
        public async Task<ActionResult<Blog>> CreateBlog([FromBody] CreateBlogRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT: api/Blogs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(Guid id, [FromBody] UpdateBlogRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // DELETE: api/Blogs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            var request = new DeleteBlogRequest { Id = id };
            await _mediator.Send(request);
            return Ok();
        }
    }
}