using GoodHamburger.Infra.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Application.Commands.PedidoCommands
{
    public class ExcluirPedidoCommandHandler : IRequestHandler<ExcluirPedidoCommand, bool>
    {
        private readonly DataContext _dataContext;
        public ExcluirPedidoCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Handle(ExcluirPedidoCommand request, CancellationToken cancellationToken)
        {

            var pedido = await _dataContext.Pedidos
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (pedido == null) { throw new Exception("Pedido não encontrado"); }

            _dataContext.Pedidos.Remove(pedido);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
