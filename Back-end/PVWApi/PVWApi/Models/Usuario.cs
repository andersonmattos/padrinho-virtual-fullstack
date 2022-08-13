using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVWApi.Models
{
    public class Usuario
    {
        [Key]
        public int LoginId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Senha { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string TemCasamento { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string CasamentoId { get; set; }
    }
}
