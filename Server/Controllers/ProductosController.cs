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
     
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Entradas>>> GetEntradas()
        {
        if (_context.Entradas == null)
        {
          return NotFound();
        }
        return await _context.Entradas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entradas>> GetEntradas(int id)
        {
        if (_context.Entradas == null)
        {
          return NotFound();
        }
        var Entradas = await _context.Entradas.FindAsync(id);

        if (Entradas == null)
        {
            return NotFound();
        }

        return Entradas;
         }

        [HttpPost]
        public async Task<ActionResult<Entradas>> PostEntradas(Entradas Entradas)
        {
        if (!EntradasExists(Entradas.ProductoId) )
            _context.Entradas.Add(Entradas);
        else
            _context.Entradas.Update(Entradas);

        await _context.SaveChangesAsync();
        return Ok(Entradas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntradas(int id)
        {
        if (_context.Entradas == null)
        {
            return NotFound();
        }
        var Entradas = await _context.Entradas.FindAsync(id);
        if (Entradas == null)
        {
            return NotFound();
        }

        _context.Entradas.Remove(Entradas);
        await _context.SaveChangesAsync();

        return NoContent();
        }

        private bool EntradasExists(int id)
        {
        return (_context.Entradas?.Any(e => e.ProductoId == id)).GetValueOrDefault();
        }
        
    }

}
