using GoodHamburger.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Dtos
{
    public class CardapioDto
    {
        public List<Sanduiche>? Sanduiches { get; set; }
        public List<Acompanhamento>? Acompanhamentos { get; set; }
    }
}
