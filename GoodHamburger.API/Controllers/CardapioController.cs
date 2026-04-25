using GoodHamburger.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardapioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CardapioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] CardapioQuery query, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(query, cancellationToken);
            return Ok(resultado);
        }
    }
}
