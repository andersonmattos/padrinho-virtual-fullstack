using Microsoft.EntityFrameworkCore;

namespace PVWApi.Models
{
    public class CelebranteContext:DbContext
    {
        public CelebranteContext(DbContextOptions<CelebranteContext> options) : base(options)
        {

        }

        public DbSet<Celebrante> Celebrante { get; set; }
    }
}
