using GoodHamburger.Application.Dtos;
using GoodHamburger.Infra.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Commands.PedidoCommands
{
    public class AtualizarPedidoCommandHandler : IRequestHandler<AtualizarPedidoCommand, PedidoDto>
    {
        private readonly DataContext _dataContext;
        public AtualizarPedidoCommandHandler(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        public async Task<PedidoDto> Handle(AtualizarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _dataContext.Pedidos
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            var sanduiche = await _dataContext.Sanduiches
               .FirstOrDefaultAsync(s => s.Id == request.SanduicheId);

            if (sanduiche == null)
                throw new InvalidOperationException("Sanduíche não encontrado.");

            var acompanhamentos = await _dataContext.Acompanhamentos
                .Where(a => request.AcompanhamentosIds.Contains(a.Id))
                .ToListAsync();

            if (acompanhamentos.Count != request.AcompanhamentosIds.Count)
                throw new InvalidOperationException("Um ou mais acompanhamentos não encontrados.");

            if (pedido == null) { throw new Exception("Pedido não encontrado"); }

            var temBatataFrita = acompanhamentos.Any(a => a.Nome == "Batata Frita");
            var temRefrigerante = acompanhamentos.Any(a => a.Nome == "Refrigerante");
            var temOsDois = temBatataFrita && temRefrigerante;

            var valor = sanduiche.Valor + acompanhamentos.Sum(a => a.Valor);
            var valorSemDeconto = valor;

            if (temOsDois)
            {
                valor *= 0.8m;
            } else if (temBatataFrita)
            {
                valor *=  0.9m;
            }
            else if (temRefrigerante)
            {
                valor *= 0.85m;
            }


            pedido.Sanduiche = sanduiche;
            pedido.Acompanhamentos = acompanhamentos;
            pedido.Observacao = request.Observacao;
            pedido.Valor = valor;

            _dataContext.Pedidos.Update(pedido);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return PedidoDto.From(pedido, valorSemDeconto);
        }
    }
}
