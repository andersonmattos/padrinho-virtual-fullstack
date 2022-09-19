using Microsoft.EntityFrameworkCore;

namespace PVWApi.Models
{
    public class BandaContext : DbContext
    {
        public BandaContext(DbContextOptions<BandaContext> options) : base(options)
        {

        }

        public DbSet<Banda> Banda { get; set; }
    }
}
