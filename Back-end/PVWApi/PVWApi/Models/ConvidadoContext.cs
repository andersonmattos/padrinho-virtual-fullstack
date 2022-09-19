using Microsoft.EntityFrameworkCore;

namespace PVWApi.Models
{
    public class ConvidadoContext : DbContext
    {
        public ConvidadoContext(DbContextOptions<ConvidadoContext> options): base(options)
        {

        }

        public DbSet<Convidado> Convidado { get; set; }
    }
}
