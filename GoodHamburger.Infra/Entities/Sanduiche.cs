using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Infra.Entities
{
    public class Sanduiche
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Nome { get; set; }
        [Required]
        public decimal Valor { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
