using Microsoft.EntityFrameworkCore;
using _2Parcial_BonillaAp1.Shared.Models;

namespace _2Parcial_BonillaAp1.Server.DAL 
{
   public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}

        public DbSet<Entradas> Entradas {get;set;} 
        public DbSet<EntradasDetalle> EntradasDetalle {get;set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TipoProductos>().HasData(new List<TipoProductos>()
        {
            new TipoProductos(){TipoId=1, Descripcion="Mani"},
            new TipoProductos(){TipoId=3, Descripcion="Pasas"},
            new TipoProductos(){TipoId=4, Descripcion="Pistacho" },
            new TipoProductos(){TipoId=5, Descripcion="Ciruela" },
            new TipoProductos(){TipoId=6, Descripcion="Arandanos"}
        });
    }

    }
}