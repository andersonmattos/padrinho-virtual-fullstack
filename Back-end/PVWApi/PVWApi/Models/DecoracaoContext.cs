using Microsoft.EntityFrameworkCore;

namespace PVWApi.Models
{
    public class DecoracaoContext:DbContext
    {
        public DecoracaoContext(DbContextOptions<DecoracaoContext> options) : base(options)
        {

        }

        public DbSet<Decoracao> Decoracao { get; set; }
    }
}
