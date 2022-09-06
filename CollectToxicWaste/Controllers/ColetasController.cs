using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Infraestrutura.EnitityFramework;

namespace CollectToxicWaste.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ColetasController : ControllerBase
    {
        private readonly Context _context;

        public ColetasController(Context context)
        {
            _context = context;
        }

        // GET: api/Coletas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coleta>>> GetColetas()
        {
            return await _context.Coletas.ToListAsync();
        }

        // GET: api/Coletas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coleta>> GetColeta(int id)
        {
            var coleta = await _context.Coletas.FindAsync(id);

            if (coleta == null)
            {
                return NotFound();
            }

            return coleta;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutColeta(int id, Coleta coleta)
        {
            if (id != coleta.Id)
            {
                return BadRequest();
            }

            _context.Entry(coleta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColetaExists(id))
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

        // POST: api/Coletas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coleta>> PostColeta(Coleta coleta)
        {
            _context.Coletas.Add(coleta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColeta", new { id = coleta.Id }, coleta);
        }

        // DELETE: api/Coletas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColeta(int id)
        {
            var coleta = await _context.Coletas.FindAsync(id);
            if (coleta == null)
            {
                return NotFound();
            }

            _context.Coletas.Remove(coleta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColetaExists(int id)
        {
            return _context.Coletas.Any(e => e.Id == id);
        }
    }
}
