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
            _context = context; ;
        }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
    {
      if (_context.Productos == null)
      {
          return NotFound();
      }
        return await _context.Productos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Productos>> GetProductos(int id)
    {
      if (_context.Productos == null)
      {
          return NotFound();
      }
        var Productos = await _context.Productos.FindAsync(id);

        if (Productos == null)
        {
            return NotFound();
        }

        return Productos;
    }

    [HttpPost]
    public async Task<ActionResult<Productos>> PostProductos(Productos Productos)
    {
        if (!ProductosExists(Productos.ProductoId) )
            _context.Productos.Add(Productos);
        else
            _context.Productos.Update(Productos);

        await _context.SaveChangesAsync();
        return Ok(Productos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductos(int id)
    {
        if (_context.Productos == null)
        {
            return NotFound();
        }
        var Productos = await _context.Productos.FindAsync(id);
        if (Productos == null)
        {
            return NotFound();
        }

        _context.Productos.Remove(Productos);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductosExists(int id)
    {
        return (_context.Productos?.Any(e => e.ProductoId == id)).GetValueOrDefault();
    }

    }

}


