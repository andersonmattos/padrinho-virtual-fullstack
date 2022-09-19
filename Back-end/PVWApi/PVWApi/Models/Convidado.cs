using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVWApi.Models
{
    public class Convidado
    {
        [Key]
        public int ConvidadoId { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string Nome { get; set; }

        [Column(TypeName = "int")]
        public int QuantidadeConvidado { get; set; }

        public virtual ICollection<Casamento> Casamento { get; set; }
    }
}
