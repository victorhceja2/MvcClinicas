using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcClinicas.Models;

namespace MvcClinicas.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcClinicas.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<MvcClinicas.Models.Login> Login { get; set; } = default!;
    }
}
