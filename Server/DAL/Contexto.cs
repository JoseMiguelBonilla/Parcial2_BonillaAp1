using Microsoft.EntityFrameworkCore;
using _2Parcial_BonillaAp1.Shared.Models;

namespace _2Parcial_BonillaAp1.Server.DAL 
{
   public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}

        public DbSet<Frutos> Frutos {get;set;} 
        public DbSet<Entradas> Entradas {get;set;} 
        public DbSet<Productos > Products {get;set;}
        public DbSet<EntradasDetalle> EntradasDetalle {get;set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Frutos>().HasData(new List<Frutos>()
        {
            new Frutos(){FrutoId=1,  Nombre="Mani" , Disponibilidad = 100},
            new Frutos(){FrutoId=2,  Nombre="Pasas", Disponibilidad = 100},
            new Frutos(){FrutoId=3,  Nombre="Pistacho", Disponibilidad = 100},
            new Frutos(){FrutoId=4,  Nombre="Ciruela" , Disponibilidad = 100},
            new Frutos(){FrutoId=5,  Nombre="Arandanos", Disponibilidad = 100},
        });
    }

    }
}