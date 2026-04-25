using GoodHamburger.Application.Dtos;
using GoodHamburger.Infra.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Queries.PedidoQueries
{
    public class ListarPedidoQueryHandler : IRequestHandler<ListarPedidoQuery, List<PedidoDto>>
    {
        private readonly DataContext _dataContext;

        public ListarPedidoQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<PedidoDto>> Handle(ListarPedidoQuery query, CancellationToken cancellationToken)
        {
            var pedidos = await _dataContext.Pedidos
                .Include(p => p.Sanduiche)
                .Include(p => p.Acompanhamentos)
                .ToListAsync(cancellationToken);

            return pedidos.Select(p =>
            {
                var valor = p.Sanduiche.Valor + p.Acompanhamentos.Sum(a => a.Valor);
                return PedidoDto.From(p, valor);
            }).ToList();
        }
    }
}
