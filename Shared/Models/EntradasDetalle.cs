using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class EntradasDetalle
    {
    
    [Key]

    public int EntradaId { get; set; }

    public int DetalleId { get; set; }

    public int TipoId { get; set; }

	public int ProductoId { get; set; }
	
    public int CantidadUtilizada { get; set; }
    
    }
}