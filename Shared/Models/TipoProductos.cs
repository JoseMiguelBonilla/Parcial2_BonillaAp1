using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class TipoProductos 
    {
        [Key]

        public int ProductoId {get; set; }

        public String? Descripcion { get; set; }

        public int Tipo { get; set; }

        public int Existencia { get; set;}
    }
}