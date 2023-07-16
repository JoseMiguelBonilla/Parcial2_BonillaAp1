using System.ComponentModel.DataAnnotations;
namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class Presentacion
    {
        [Key]
        public int PresentacionId { get; set; }
        public String? Descripcion { get; set; }
    }
}