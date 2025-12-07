using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mecanica.NET
{
    [Route("api/[controller]")]
    [ApiController]
    public class empleadoController : ControllerBase
    {
        private readonly AngularDbContext _context;

        public empleadoController(AngularDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<empleadoModel>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<empleadoModel>> GetempleadoModel(long id)
        {
            var empleadoModel = await _context.Empleados.FindAsync(id);

            if (empleadoModel == null)
            {
                return NotFound();
            }

            return empleadoModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutempleadoModel(long id, empleadoModel empleadoModel)
        {
            if (id != empleadoModel.id)
            {
                return BadRequest();
            }

            _context.Entry(empleadoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!empleadoModelExists(id))
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
        public async Task<ActionResult<empleadoModel>> PostempleadoModel(empleadoModel empleadoModel)
        {
            _context.Empleados.Add(empleadoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetempleadoModel", new { id = empleadoModel.id }, empleadoModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteempleadoModel(long id)
        {
            var empleadoModel = await _context.Empleados.FindAsync(id);
            if (empleadoModel == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleadoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool empleadoModelExists(long id)
        {
            return _context.Empleados.Any(e => e.id == id);
        }
    }
}