using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVWApi.Models
{
    public class Buffet
    {
        [Key]
        public int BuffetId { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string Nome { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan HorasContratadas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Column(TypeName = "varchar(400)")]
        public string Comidas { get; set; }                

        public virtual ICollection<Festa> Festa { get; set; }

    }
}
