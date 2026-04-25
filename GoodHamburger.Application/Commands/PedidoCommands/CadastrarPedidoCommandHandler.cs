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

namespace GoodHamburger.Application.Commands.PedidoCommands
{
    public class CadastrarPedidoCommandHandler : IRequestHandler<CadastrarPedidoCommand, PedidoDto>
    {
        private readonly DataContext _dataContext;
        public CadastrarPedidoCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PedidoDto> Handle(CadastrarPedidoCommand request, CancellationToken cancellationToken)
        {

            if (request == null) { throw new Exception("Pedido não pode ser vazio"); }

            var sanduiche = await _dataContext.Sanduiches
                .FirstOrDefaultAsync(s => s.Id == request.SanduicheId);

            if (sanduiche == null)
                throw new InvalidOperationException("Sanduíche não encontrado.");

            var acompanhamentos = await _dataContext.Acompanhamentos
                .Where(a => request.AcompanhamentosIds.Contains(a.Id))
                .ToListAsync();

            if (acompanhamentos.Count != request.AcompanhamentosIds.Count)
                throw new InvalidOperationException("Um ou mais acompanhamentos não encontrados.");

            var temBatataFrita = acompanhamentos.Any(a => a.Nome == "Batata Frita");
            var temRefrigerante = acompanhamentos.Any(a => a.Nome == "Refrigerante");
            var temOsDois = temBatataFrita && temRefrigerante;

            var valor = sanduiche.Valor + acompanhamentos.Sum(a => a.Valor);


            if (temOsDois)
            {
                valor *= 0.8m;
            }
            else if (temBatataFrita)
            {
                valor *= 0.9m;
            }
            else if (temRefrigerante)
            {
                valor *= 0.85m;
            }

            var pedido = new Pedido
            {
                Sanduiche = sanduiche,
                Acompanhamentos = acompanhamentos,
                Observacao = request.Observacao,
                Valor = valor,
            };

            await _dataContext.Pedidos.AddAsync(pedido, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return PedidoDto.From(pedido);
        }
    }
}
