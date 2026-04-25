using GoodHamburger.Application.Dtos;
using GoodHamburger.Infra.Data;
using GoodHamburger.Infra.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Queries.PedidoQueries
{
    public class BuscarPedidoQueryHandler : IRequestHandler<BuscarPedidoQuery, PedidoDto>
    {
        private readonly DataContext _dataContext;

        public BuscarPedidoQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PedidoDto> Handle(BuscarPedidoQuery query, CancellationToken cancellationToken)
        {
            var pedido = await _dataContext.Pedidos
                .Include(p => p.Sanduiche)
                .Include(p => p.Acompanhamentos)
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (pedido == null) { throw new InvalidOperationException("Pedido não encontrado."); }

            var valor = pedido.Sanduiche.Valor + pedido.Acompanhamentos.Sum(a => a.Valor);

            return PedidoDto.From(pedido, valor);
        }
    }
}
