using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mecanica.NET
{
    [Route("api/[controller]")]
    [ApiController]
    public class servicioController : ControllerBase
    {
        private readonly AngularDbContext _context;

        public servicioController(AngularDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<servicioModel>>> GetServicios()
        {
            return await _context.Servicios
                .Include(v => v.Vehiculo)
                .Include(u => u.Usuario)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<servicioModel>> GetservicioModel(long id)
        {
            var servicioModel = await _context.Servicios
                .Include(v => v.Vehiculo)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(s => s.id == id);

            if (servicioModel == null)
            {
                return NotFound();
            }

            return servicioModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutservicioModel(long id, servicioModel servicioModel)
        {
            if (id != servicioModel.id)
            {
                return BadRequest();
            }

            _context.Entry(servicioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!servicioModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<servicioModel>> PostservicioModel(servicioModel servicioModel)
        {
            _context.Servicios.Add(servicioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetservicioModel", new { id = servicioModel.id }, servicioModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteservicioModel(long id)
        {
            var servicioModel = await _context.Servicios.FindAsync(id);
            if (servicioModel == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool servicioModelExists(long id)
        {
            return _context.Servicios.Any(e => e.id == id);
        }
    }
}