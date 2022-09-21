using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVWApi.Models
{
    public class Cerimonia
    {
        [Key]
        public int CerimoniaId { get; set; }        

        [Column(TypeName = "bit")]
        public Boolean Civil { get; set; }

        [Column(TypeName = "bit")]
        public Boolean Religiosa { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Local { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "int")]
        public int CelebranteId { get; set; }

        public virtual Celebrante Celebrante { get; set; }

        public virtual ICollection<Casamento> Casamento { get; set; }
        
    }
}
