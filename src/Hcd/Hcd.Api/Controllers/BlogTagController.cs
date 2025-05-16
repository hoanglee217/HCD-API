using Hcd.Common.Requests.Management.BlogTag;

using Hcd.Data.Entities.Management;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers;

[ApiController]
[Route("api/blog-tag")]
[Authorize]
public class BlogTagController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<List<BlogTag>>> GetAllBlogTags([FromQuery] GetAllBlogTagsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogTag>> GetDetailBlogTag(Guid id)
    {
        var request = new GetDetailBlogTagRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<BlogTag>> CreateBlogTag([FromBody] CreateBlogTagRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateBlogTag(Guid id, [FromBody] UpdateBlogTagRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogTag(Guid id)
    {
        var request = new DeleteBlogTagRequest { Id = id };
        await _mediator.Send(request);
        return Ok();
    }
}