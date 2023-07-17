using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using _2Parcial_BonillaAp1.Server.DAL;
using _2Parcial_BonillaAp1.Shared.Models;

namespace _2Parcial_BonillaAp1.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class EntradasController : ControllerBase
    {
        private readonly Contexto _context;

        public EntradasController(Contexto context)
        {
            _context = context;
        }

        public bool Existe(int EntradaId)
        {
            return (_context.Entradas?.Any(e => e.EntradaId == EntradaId)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entradas>>> Obtener()
        {
            if (_context.Entradas == null)
            {
                return NotFound();
            }
            else
            {
                return await _context.Entradas.ToListAsync();
            }
        }

        [HttpGet("{EntradaId}")]
        public async Task<ActionResult<Entradas>> ObtenerEntradas(int EntradaId)
        {
            if (_context.Entradas == null)
            {
                return NotFound();
            }

            var Entradas = await _context.Entradas.Include(e => e.EntradasDetalles).Where(e => e.EntradaId == EntradaId).FirstOrDefaultAsync();

            if (Entradas == null)
            {
                return NotFound();
            }

            foreach (var item in Entradas.EntradasDetalles)
            {
                Console.WriteLine($"{item.DetalleId}, {item.EntradaId}, {item.ProductoId}, {item.CantidadUtilizada}");
            }

            return Entradas;
        }

        [HttpPost]
        public async Task<ActionResult<Entradas>> PostEntradas(Entradas Entradas)
        {
            if (!Existe(Entradas.EntradaId))
            {
                Productos? producto = new Productos();
                foreach (var productoConsumido in Entradas.EntradasDetalles)
                {
                    producto = _context.Productos.Find(productoConsumido.ProductoId);

                    if (producto != null)
                    {
                        producto.Existencia -= productoConsumido.CantidadUtilizada;
                        _context.Productos.Update(producto);
                        await _context.SaveChangesAsync();
                        _context.Entry(producto).State = EntityState.Detached;
                    }
                }
                await _context.Entradas.AddAsync(Entradas);
            }
            else
            {
                var EntradasAnterior = _context.Entradas.Include(e => e.EntradasDetalles).AsNoTracking()
                .FirstOrDefault(e => e.EntradaId == Entradas.EntradaId);

                Productos? producto = new Productos();

                if (EntradasAnterior != null && EntradasAnterior.EntradasDetalles != null)
                {
                    foreach (var productoConsumido in EntradasAnterior.EntradasDetalles)
                    {
                        if (productoConsumido != null)
                        {
                            producto = _context.Productos.Find(productoConsumido.ProductoId);

                            if (producto != null)
                            {
                                producto.Existencia += productoConsumido.CantidadUtilizada;
                                _context.Productos.Update(producto);
                                await _context.SaveChangesAsync();
                                _context.Entry(producto).State = EntityState.Detached;
                            }
                        }
                    }
                }

                if (EntradasAnterior != null)
                {
                    producto = _context.Productos.Find(EntradasAnterior.ProductoId);

                    if (producto != null)
                    {
                        producto.Existencia -= EntradasAnterior.CantidadProducida;
                        _context.Productos.Update(producto);
                        await _context.SaveChangesAsync();
                        _context.Entry(producto).State = EntityState.Detached;
                    }
                }

                _context.Database.ExecuteSqlRaw($"Delete from EntradasDetalles where EntradaId = {Entradas.EntradaId}");

                foreach (var productoConsumido in Entradas.EntradasDetalles)
                {
                    producto = _context.Productos.Find(productoConsumido.ProductoId);

                    if (producto != null)
                    {
                        producto.Existencia -= productoConsumido.CantidadUtilizada;
                        _context.Productos.Update(producto);
                        await _context.SaveChangesAsync();
                        _context.Entry(producto).State = EntityState.Detached;
                        _context.Entry(productoConsumido).State = EntityState.Added;
                    }
                }

                producto = _context.Productos.Find(Entradas.ProductoId);

                if (producto != null)
                {
                    producto.Existencia += Entradas.CantidadProducida;
                    _context.Productos.Update(producto);
                    await _context.SaveChangesAsync();
                    _context.Entry(producto).State = EntityState.Detached;
                }
                _context.Entradas.Update(Entradas);
            }

            await _context.SaveChangesAsync();
            _context.Entry(Entradas).State = EntityState.Detached;
            return Ok(Entradas);
        }

        [HttpDelete("{EntradaId}")]
        public async Task<IActionResult> EliminarEntradas(int EntradaId)
        {
            var Entradas = await _context.Entradas.Include(e => e.EntradasDetalles).FirstOrDefaultAsync(e => e.EntradaId == EntradaId);

            if (Entradas == null)
            {
                return NotFound();
            }

            foreach (var productoConsumido in Entradas.EntradasDetalles)
            {
                var producto = await _context.Productos.FindAsync(productoConsumido.ProductoId);

                if (producto != null)
                {
                    producto.Existencia += productoConsumido.CantidadUtilizada;
                    _context.Productos.Update(producto);
                }
            }

            var productoInicial = await _context.Productos.FindAsync(Entradas.ProductoId);

            if (productoInicial != null)
            {
                productoInicial.Existencia += Entradas.CantidadProducida;
                _context.Productos.Update(productoInicial);
            }

            _context.Entradas.Remove(Entradas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}