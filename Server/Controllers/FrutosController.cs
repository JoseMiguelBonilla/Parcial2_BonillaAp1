using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using _2Parcial_BonillaAp1.Server.DAL;
using _2Parcial_BonillaAp1.Shared.Models;

namespace _2Parcial_BonillaAp1.Server.Controller
{
    
        [Route("api/[controller]")]
        [ApiController]

        public class FrutosController : ControllerBase
        {
        private readonly Contexto _context;

        public FrutosController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
         public async Task<ActionResult<IEnumerable<Frutos>>> GetFrutos()
        {
        if (_context.Frutos == null)
        {
          return NotFound();
        }
        return await _context.Frutos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Frutos>> GetFrutos(int id)
        {
        if (_context.Frutos == null)
        {
          return NotFound();
        }
        var Frutos = await _context.Frutos.FindAsync(id);

        if (Frutos == null)
        {
            return NotFound();
        }

        return Frutos;
         }

        [HttpPost]
        public async Task<ActionResult<Frutos>> PostFrutos(Frutos Frutos)
        {
        if (!FrutosExists(Frutos.FrutoId) )
            _context.Frutos.Add(Frutos);
        else
            _context.Frutos.Update(Frutos);

        await _context.SaveChangesAsync();
        return Ok(Frutos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrutos(int id)
        {
        if (_context.Frutos == null)
        {
            return NotFound();
        }
        var Frutos = await _context.Frutos.FindAsync(id);
        if (Frutos == null)
        {
            return NotFound();
        }

        _context.Frutos.Remove(Frutos);
        await _context.SaveChangesAsync();

        return NoContent();
        }

        private bool FrutosExists(int id)
        {
        return (_context.Frutos?.Any(e => e.FrutoId == id)).GetValueOrDefault();
        }
        
    }

}
