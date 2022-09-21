using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace PVWApi.Models
{
    public class CasamentoContext : DbContext
    {
        public CasamentoContext(DbContextOptions<CasamentoContext> options) : base(options)
        {
        
        }

        public DbSet<Casamento> Casamento { get; set; }
    }
}
