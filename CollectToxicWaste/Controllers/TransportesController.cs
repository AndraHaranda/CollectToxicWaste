﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.EnitityFramework;

namespace CollectToxicWaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportesController : ControllerBase
    {
        private readonly Context _context;

        public TransportesController(Context context)
        {
            _context = context;
        }

        // GET: api/Transportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transporte>>> GetTransportes()
        {
            return await _context.Transportes.ToListAsync();
        }

        // GET: api/Transportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transporte>> GetTransporte(int id)
        {
            var transporte = await _context.Transportes.FindAsync(id);

            if (transporte == null)
            {
                return NotFound();
            }

            return transporte;
        }

        // PUT: api/Transportes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransporte(int id, Transporte transporte)
        {
            if (id != transporte.Id)
            {
                return BadRequest();
            }

            _context.Entry(transporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransporteExists(id))
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

        // POST: api/Transportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transporte>> PostTransporte(Transporte transporte)
        {
            _context.Transportes.Add(transporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransporte", new { id = transporte.Id }, transporte);
        }

        // DELETE: api/Transportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransporte(int id)
        {
            var transporte = await _context.Transportes.FindAsync(id);
            if (transporte == null)
            {
                return NotFound();
            }

            _context.Transportes.Remove(transporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransporteExists(int id)
        {
            return _context.Transportes.Any(e => e.Id == id);
        }
    }
}
