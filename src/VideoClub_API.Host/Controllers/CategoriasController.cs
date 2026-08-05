using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoClub_API.Business.Features.Categorias.Commands;
using VideoClub_API.Business.Features.Categorias.Queries;

namespace VideoClub_API.Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetCategoriasQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoriaCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }
}