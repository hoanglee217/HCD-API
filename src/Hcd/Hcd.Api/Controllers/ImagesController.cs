using Hcd.Common.Exceptions;
using Hcd.Common.Requests.System.Images;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Api.Controllers;

[ApiController]
[Route("api/images")]
[Authorize]
public class ImagesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllImages([FromQuery] GetAllImagesRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetailImage(Guid id)
    {
        var request = new GetDetailImageRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        var request = new UploadImageRequest { File = file };
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