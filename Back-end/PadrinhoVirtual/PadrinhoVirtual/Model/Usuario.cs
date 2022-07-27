using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PadrinhoVirtual.Model
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

    }
}
