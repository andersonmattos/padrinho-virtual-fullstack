using Microsoft.EntityFrameworkCore;

namespace PVWApi.Models
{
    public class CerimoniaContext : DbContext
    {
        public CerimoniaContext(DbContextOptions<CerimoniaContext> options) : base(options)
        {

        }

        public DbSet<Cerimonia> Cerimonia { get; set; }
    }
}
