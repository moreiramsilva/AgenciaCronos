using Microsoft.EntityFrameworkCore;
using AgenciaCronosAPI.Models;

namespace WebApplicationTeste.Data
{
    public class AgenciaCronosAPIContext : DbContext
    {
        public AgenciaCronosAPIContext(DbContextOptions<AgenciaCronosAPIContext> options)
            : base(options)
        {
        }

        public DbSet<IntegrantesEquipe> integrantesEquipe { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Servicos> servicos { get; set; }
        public DbSet<Post> post { get; set; }

    }
}
