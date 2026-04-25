using GoodHamburger.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Queries.PedidoQueries
{
    public class BuscarPedidoQuery : IRequest<PedidoDto>
    {
        public int Id { get; set; }
    }
}
