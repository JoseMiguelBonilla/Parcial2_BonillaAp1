using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class EntradasDetalle
    {
    [Key]
    public int DetalleId { get; set; }

    public int EntradaId { get; set; }

    public int ProductoId { get; set; }

    public int CantidadUtilizada { get; set; }

    public String? Descripcion { get; set; }

    public String? Nombre { get; set; }

    public int Disponibilidad { get; set; }

    }
}