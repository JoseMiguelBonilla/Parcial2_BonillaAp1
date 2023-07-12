using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class Frutos 
    {
        [Key]
        public int FrutoId { get; set; }

        public String? Nombre { get; set; }

        public int Disponibilidad { get; set; }
    }
}