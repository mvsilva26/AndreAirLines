using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAPI.Model;

namespace AndreAPI.Data
{
    public class AndreAPIContext : DbContext
    {
        public AndreAPIContext (DbContextOptions<AndreAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAPI.Model.Endereco> Endereco { get; set; }

        public DbSet<AndreAPI.Model.Passageiro> Passageiro { get; set; }

        public DbSet<AndreAPI.Model.Aeronave> Aeronave { get; set; }

        public DbSet<AndreAPI.Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<AndreAPI.Model.Voo> Voo { get; set; }
    }
}
