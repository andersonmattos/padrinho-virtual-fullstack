using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVWApi.Models
{
    public class Celebrante
    {
        [Key]
        public int CelebranteId { get; set; }
                
        [Column(TypeName = "varchar(70)")]
        public string Nome { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan HorasContratadas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        public virtual ICollection<Cerimonia>? Cerimonia { get; set; }
        
    }
}
