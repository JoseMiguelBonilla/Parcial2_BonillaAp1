using Microsoft.EntityFrameworkCore;
using _2Parcial_BonillaAp1.Shared.Models;

namespace _2Parcial_BonillaAp1.Server.DAL 
{
   public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}

        public DbSet<EntradasProductos> EntradasProductos {get;set;} 
        public DbSet<ProductosDetalle> ProductosDetalles {get;set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TipoProductos>().HasData(new List<TipoProductos>()
        {
            new TipoProductos(){Tipo=1, Descripcion="Mani"},
            new TipoProductos(){Tipo=3, Descripcion="Pasas"},
            new TipoProductos(){Tipo=4, Descripcion="Pistacho" },
            new TipoProductos(){Tipo=5, Descripcion="Ciruela" },
            new TipoProductos(){Tipo=6, Descripcion="Arandanos"}
        });
    }

    }
}