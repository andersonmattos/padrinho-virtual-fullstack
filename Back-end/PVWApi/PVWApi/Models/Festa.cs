﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVWApi.Models
{
    public class Festa
    {
        [Key]
        public int FestaId { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string NomeLocal { get; set; }

        [Column(TypeName = "int")]
        public int Capacidade { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan HorasContratadas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        /*[Column(TypeName = "int")]
        public int BuffetId { get; set; }

        [Column(TypeName = "int")]
        public int BandaId { get; set; }*/

        [ForeignKey("BuffetId")]
        public virtual Buffet? Buffet { get; set; }

        [ForeignKey("BandaId")]
        public virtual Banda? Banda { get; set; }

        public virtual ICollection<Casamento>? Casamento { get; set; }

    }
}
