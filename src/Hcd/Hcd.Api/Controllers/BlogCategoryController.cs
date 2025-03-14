using Hcd.Common.Requests.Management.BlogCategory;

using Hcd.Data.Entities.Management;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/BlogCategory")]
    [Authorize]
    public class BlogCategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<ActionResult<List<BlogCategory>>> GetAllBlogCategory([FromQuery] GetAllBlogCategoriesRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET: api/BlogCategory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogCategory>> GetDetailBlogCategory(Guid id)
        {
            var request = new GetDetailBlogCategoryRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // POST: api/BlogCategory
        [HttpPost]
        public async Task<ActionResult<BlogCategory>> CreateBlogCategory([FromBody] CreateBlogCategoryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT: api/BlogCategory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogCategory(Guid id, [FromBody] UpdateBlogCategoryRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // DELETE: api/BlogCategory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogCategory(Guid id)
        {
            var request = new DeleteBlogCategoryRequest { Id = id };
            await _mediator.Send(request);
            return Ok();
        }
    }
}