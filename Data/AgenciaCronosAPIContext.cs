using Microsoft.EntityFrameworkCore;
using AgenciaCronosAPI.Models;

namespace AgenciaCronosAPI.Data
{
    public class AgenciaCronosAPIContext : DbContext
    {
        public AgenciaCronosAPIContext (DbContextOptions<AgenciaCronosAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<IntegrantesEquipe> IntegrantesEquipe { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
    }
}