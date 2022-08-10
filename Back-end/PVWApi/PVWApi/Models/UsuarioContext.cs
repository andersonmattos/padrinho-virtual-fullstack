using Microsoft.EntityFrameworkCore;

namespace PVWApi.Models
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
