using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVWApi.Models
{
    public class Decoracao
    {
        [Key]
        public int DecoracaoId { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Item { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        public virtual ICollection<Casamento>? Casamento { get; set; }
    }
}
