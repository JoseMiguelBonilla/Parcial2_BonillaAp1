using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Parcial_BonillaAp1.Shared.Models
{
    public class ProductosDetalle
    {
    
    [Key]
    public int DetalleId { get; set; }

	public int ProductoId { get; set; }

	public string? Producto { get; set; }

	public string? Descripcion { get; set; }
	
    public int Cantidad { get; set; }
    
    }
}