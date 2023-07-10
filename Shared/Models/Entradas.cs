using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class Entradas
    {
		/*descripcion de los productos*/ 
	[Key]

	[Required(ErrorMessage = "El EntradaId es requerido")]
	public int EntradaId { get; set; }

	public DateTime Fecha { get; set; }

	public string? Concepto { get; set; }

	public int PesoTotal { get; set; }

	public int ProductoId { get; set; }

	public int CantidadProducida { get; set;}

	[ForeignKey("EntradaId")]
	public ICollection<ProductosDetalle> ClientesDetalle { get; set; } = new List<ProductosDetalle>();
    
    }

    }
