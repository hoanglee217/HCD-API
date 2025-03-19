using Hcd.Common.Requests.System.Image;
using Hcd.Data.Entities.System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers;

[ApiController]
[Route("api/Image")]
[Authorize]
public class ImageController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult<List<Image>>> GetAllImages(GetAllImageRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult<Image>> GetDetailImage(GetDetailImageRequest request)
    {
        var request = new GetDetailImageRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult<Image>> CreateImage([FromBody] CreateImageRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateImage(Guid id, [FromBody] UpdateImageRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(Guid id)
    {
        var request = new DeleteImageRequest { Id = id };
        await _mediator.Send(request);
        return Ok();
    }
}