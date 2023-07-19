using Microsoft.EntityFrameworkCore;
using _2Parcial_BonillaAp1.Shared.Models;

namespace _2Parcial_BonillaAp1.Server.DAL 
{
   public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}
        public DbSet<Entradas> Entradas {get;set;} 
        public DbSet<Productos > Productos {get;set;}
        public DbSet<Presentacion> Presentaciones {get;set;}
        public DbSet<EntradasDetalles> EntradasDetalles {get;set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Presentacion>().HasData(new List<Presentacion>()
        {
            new Presentacion(){PresentacionId=1,  Descripcion="Saco" },
            new Presentacion(){PresentacionId=2,  Descripcion="Caja"},
        });

        modelBuilder.Entity<Productos>().HasData(new List<Productos>()
        {
            new Productos(){ProductoId=1,  Descripcion="Mani" , Existencia = 100, Peso=100 , PresentacionId=1},
            new Productos(){ProductoId=2,  Descripcion="Pasas", Existencia = 100, Peso=100, PresentacionId=1},
            new Productos(){ProductoId=3,  Descripcion="Pistacho", Existencia = 100, Peso=100, PresentacionId=1},
            new Productos(){ProductoId=4,  Descripcion="Ciruela" , Existencia = 100, Peso=100, PresentacionId=1},
            new Productos(){ProductoId=5,  Descripcion="Arandanos", Existencia = 100, Peso=100, PresentacionId=1},
            new Productos(){ProductoId=6,  Descripcion="Producto Mixto", Existencia = 0, Peso=1, PresentacionId=2}
        });
    
    }

    }
}