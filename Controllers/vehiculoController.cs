using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mecanica.NET;

namespace Mecanica.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vehiculoController : ControllerBase
    {
        private readonly AngularDbContext _context;

        public vehiculoController(AngularDbContext context)
        {
            _context = context;
        }

        // GET: api/vehiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vehiculoModel>>> GetVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        // GET: api/vehiculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<vehiculoModel>> GetvehiculoModel(long id)
        {
            var vehiculoModel = await _context.Vehiculos.FindAsync(id);

            if (vehiculoModel == null)
            {
                return NotFound();
            }

            return vehiculoModel;
        }

        // PUT: api/vehiculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutvehiculoModel(long id, vehiculoModel vehiculoModel)
        {
            if (id != vehiculoModel.id)
            {
                return BadRequest();
            }

            _context.Entry(vehiculoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vehiculoModelExists(id))
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

        // POST: api/vehiculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<vehiculoModel>> PostvehiculoModel(vehiculoModel vehiculoModel)
        {
            _context.Vehiculos.Add(vehiculoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetvehiculoModel", new { id = vehiculoModel.id }, vehiculoModel);
        }

        // DELETE: api/vehiculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletevehiculoModel(long id)
        {
            var vehiculoModel = await _context.Vehiculos.FindAsync(id);
            if (vehiculoModel == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool vehiculoModelExists(long id)
        {
            return _context.Vehiculos.Any(e => e.id == id);
        }
    }
}
