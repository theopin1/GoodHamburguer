using GoodHamburger.Application.Commands.PedidoCommands;
using GoodHamburger.Application.Queries.PedidoQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] ListarPedidoQuery query, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(query, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscar(int id, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _mediator.Send(new BuscarPedidoQuery { Id = id }, cancellationToken);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CadastrarPedidoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _mediator.Send(command, cancellationToken);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarPedidoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _mediator.Send(command, cancellationToken);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id, CancellationToken cancellationToken)
        {
            try 
            {
                var command = new ExcluirPedidoCommand { Id = id };
                var resultado = await _mediator.Send(command, cancellationToken);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
