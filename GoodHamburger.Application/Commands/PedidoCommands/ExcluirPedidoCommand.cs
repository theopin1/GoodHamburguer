using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Commands.PedidoCommands
{
    public class ExcluirPedidoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
