using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class Productos 
    {
       [Key]

        public int ProductoId {get; set; }

        public String? Descripcion { get; set; }
        
        public int Existencia { get; set;}

        public decimal Peso { get; set; }

        public int PresentacionId { get; set; } = 2;
    }
}