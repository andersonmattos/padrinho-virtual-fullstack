using Microsoft.EntityFrameworkCore;

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
