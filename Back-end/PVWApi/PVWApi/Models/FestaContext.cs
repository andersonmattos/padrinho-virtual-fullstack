using Microsoft.EntityFrameworkCore;

namespace PVWApi.Models
{
    public class FestaContext : DbContext
    {
        public FestaContext(DbContextOptions<FestaContext> options) : base(options)
        {

        }

        public DbSet<Festa> Festa { get; set; }
    }
}
