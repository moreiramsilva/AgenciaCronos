#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<AgenciaCronosAPI.Models.Usuario> Usuario { get; set; }
        public DbSet<AgenciaCronosAPI.Models.Post> Post { get; set; }
        public DbSet<AgenciaCronosAPI.Models.IntegrantesEquipe> IntegrantesEquipe { get; set; }
        public DbSet<AgenciaCronosAPI.Models.Servicos> Servicos { get; set; }
    }
}
