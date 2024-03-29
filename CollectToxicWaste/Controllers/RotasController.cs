﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.EnitityFramework;

namespace CollectToxicWaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotasController : ControllerBase
    {
        private readonly Context _context;

        public RotasController(Context context)
        {
            _context = context;
        }

        // GET: api/Rotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rota>>> GetRotas()
        {
            return await _context.Rotas.ToListAsync();
        }

        // GET: api/Rotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rota>> GetRota(int id)
        {
            var rota = await _context.Rotas.FindAsync(id);

            if (rota == null)
            {
                return NotFound();
            }

            return rota;
        }

        // PUT: api/Rotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRota(int id, Rota rota)
        {
            if (id != rota.Id)
            {
                return BadRequest();
            }

            _context.Entry(rota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaExists(id))
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

        // POST: api/Rotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rota>> PostRota(Rota rota)
        {
            _context.Rotas.Add(rota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRota", new { id = rota.Id }, rota);
        }

        // DELETE: api/Rotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRota(int id)
        {
            var rota = await _context.Rotas.FindAsync(id);
            if (rota == null)
            {
                return NotFound();
            }

            _context.Rotas.Remove(rota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotaExists(int id)
        {
            return _context.Rotas.Any(e => e.Id == id);
        }
    }
}
