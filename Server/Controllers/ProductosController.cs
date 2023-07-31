using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using _2Parcial_BonillaAp1.Server.DAL;
using _2Parcial_BonillaAp1.Shared.Models;


namespace _2Parcial_BonillaAp1.Server.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class ProductosController : ControllerBase
    {
        private readonly Contexto _context;

        public ProductosController(Contexto context)
        {
            _context = context;
        }

        public bool Existe(int ProductoId)
        {
            return (_context.Productos?.Any(p => p.ProductoId == ProductoId)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> Obtener()
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            else
            {
                return await _context.Productos.ToListAsync();
            }
        }

        [HttpGet("{ProductoId}")]
        public async Task<ActionResult<Productos>> ObtenerProductos(int ProductoId)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(ProductoId);

            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            if (!Existe(productos.ProductoId))
            {
                _context.Productos.Add(productos);
            }
            else
            {
                _context.Productos.Update(productos);
            }

            await _context.SaveChangesAsync();
            return Ok(productos);
        }

        [HttpDelete("{ProductoId}")]
        public async Task<IActionResult> Eliminar(int ProductoId)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(ProductoId);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
