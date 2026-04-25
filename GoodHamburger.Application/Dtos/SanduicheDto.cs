using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Dtos
{
    public class SanduicheDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Valor { get; set; }
        public string Descricao { get; set; }
    }
}
