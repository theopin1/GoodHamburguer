using GoodHamburger.Application.Dtos;
using GoodHamburger.Infra.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace GoodHamburger.Application.Commands.PedidoCommands
{
    public class CadastrarPedidoCommand : IRequest<PedidoDto>
    {
        public int SanduicheId { get; set; }
        public List<int>? AcompanhamentosIds { get; set; }
        public string? Observacao { get; set; }
    }
}
