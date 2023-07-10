using Microsoft.EntityFrameworkCore;
using _2Parcial_BonillaAp1.Shared.Models;

namespace _2Parcial_BonillaAp1.Server.DAL

{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}

        public DbSet<Productos> Productos {get;set;} 
        public DbSet<ProductosDetalle> ProductosDetalles {get;set;} 

    }
}


