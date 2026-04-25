using GoodHamburger.Infra.Entities;
using System.Text.Json.Serialization;

namespace GoodHamburger.Application.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public Sanduiche? Sanduiche { get; set; }
        public List<Acompanhamento>? Acompanhamentos { get; set; }
        public string? Observacao { get; set; }
        public decimal? Valor { get; set; }
        public decimal ValorComDesconto { get; set; }


        public static PedidoDto From(Pedido pedido, decimal valor)
        {
            return new PedidoDto
            {
                Id = pedido.Id,
                Sanduiche = pedido.Sanduiche,
                Acompanhamentos = pedido.Acompanhamentos,
                Observacao = pedido.Observacao,
                ValorComDesconto = pedido.Valor,
                Valor = valor
            };
        }

        public static PedidoDto From(Pedido pedido)
        {
            return new PedidoDto
            {
                Id = pedido.Id,
                Sanduiche = pedido.Sanduiche,
                Acompanhamentos = pedido.Acompanhamentos,
                Observacao = pedido.Observacao,
                Valor = null,
                ValorComDesconto = pedido.Valor
            };
        }
    }
}
