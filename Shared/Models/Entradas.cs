using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class Entradas
    {
	
	[Key]
	public int EntradaId { get; set; }

	public DateTime Fecha { get; set; } = DateTime.Now;

	public string? Concepto { get; set; }

	public int CantidadProducida { get; set;}

	public decimal PesoTotal { get; set; }

	public int ProductoId { get; set; }

	[ForeignKey("EntradaId")]
	public ICollection<EntradasDetalles> EntradasDetalles { get; set; } = new List<EntradasDetalles>();
    
    }

}
