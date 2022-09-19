using Microsoft.EntityFrameworkCore;

namespace PVWApi.Models
{
    public class BuffetContext : DbContext
    {
        public BuffetContext(DbContextOptions<BuffetContext> options) : base(options)
        {

        }

        public DbSet<Buffet> Buffet { get; set; }
    }
}
