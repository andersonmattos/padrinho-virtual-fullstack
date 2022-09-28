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

        /*[Column(TypeName = "int")]
        public int UsuarioId { get; set; }

        [Column(TypeName = "int")]
        public int FestaId { get; set; }

        [Column(TypeName = "int")]
        public int DecoracaoId { get; set; }

        [Column(TypeName = "int")]
        public int CerimoniaId { get; set; }*/

        [ForeignKey("LoginId")]
        public virtual Usuario? Usuario { get; set; }
        
        [ForeignKey("FestaId")]
        public virtual Festa? Festa { get; set; }
        
        [ForeignKey("CerimoniaId")]
        public virtual Cerimonia? Cerimonia { get; set; }

        [ForeignKey("DecoracaoId")]
        public virtual Decoracao? Decoracao { get; set; }
        public virtual ICollection<Convidado>? Convidado { get; set; }
    }
}
