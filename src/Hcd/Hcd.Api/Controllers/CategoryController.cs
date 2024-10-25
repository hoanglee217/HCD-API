using Hcd.Common.Exceptions;
using Hcd.Common.Requests.Category;
using Hcd.Data.Entities.Management.Blog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories(GetAllCategoriesRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(Guid? id, GetDetailCategoryRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Category id not found!");
            }
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid? id, [FromBody] UpdateCategoryRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Category id not found!");
            }
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid? id, DeleteCategoryRequest request)
        {
            if (id == null)
            {
                throw new NotFoundException("Category id not found!");
            }
            await _mediator.Send(request);
            return Ok();
        }
    }
}