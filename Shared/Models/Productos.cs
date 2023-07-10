using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class Productos
    {
	[Key]

	[Required(ErrorMessage = "El ProductoId es requerido")]
	public int ProductoId { get; set; }

	public DateTime Fecha { get; set; }

	public string? Concepto { get; set; }

	[ForeignKey("ProductoId")]
	public ICollection<ProductosDetalle> ClientesDetalle { get; set; } = new List<ProductosDetalle>();
    
    }

    }
