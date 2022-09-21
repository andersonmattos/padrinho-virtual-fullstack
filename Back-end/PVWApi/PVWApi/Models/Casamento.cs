using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVWApi.Models
{
    public class Casamento
    {
        [Key]
        public int CasamentoId { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string NomeParceiroA { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string NomeParceiroB { get; set; }

        [Column(TypeName = "bit")]
        public Boolean Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Column(TypeName = "int")]
        public int UsuarioId { get; set; }

        [Column(TypeName = "int")]
        public int FestaId { get; set; }

        [Column(TypeName = "int")]
        public int DecoracaoId { get; set; }        

        public virtual Usuario Usuario { get; set; }
        public virtual Festa Festa { get; set; }
        public virtual Cerimonia Cerimonia { get; set; }
        public virtual Decoracao Decoracao { get; set; }
        public virtual ICollection<Convidado> Convidado { get; set; }
    }
}
