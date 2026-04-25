using System.ComponentModel.DataAnnotations;

namespace GoodHamburger.Infra.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public Sanduiche? Sanduiche { get; set; }
        public List<Acompanhamento>? Acompanhamentos { get; set; } = new();
        public string? Observacao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
