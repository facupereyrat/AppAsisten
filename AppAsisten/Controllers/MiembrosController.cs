using AppAsisten.BD.Data;
using AppAsisten.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAsisten.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiembrosController : ControllerBase
    {
        private readonly Context _context;

        public MiembrosController(Context context)
        {
            _context = context;
        }

        // GET: api/Miembros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Miembro>>> GetMiembros()
        {
            return await _context.Miembros
                .Include(m => m.Asistencias)  // Incluir las asistencias relacionadas
                .ToListAsync();
        }

        // GET: api/Miembros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Miembro>> GetMiembro(int id)
        {
            var miembro = await _context.Miembros
                .Include(m => m.Asistencias)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (miembro == null)
            {
                return NotFound();
            }

            return miembro;
        }

        // POST: api/Miembros
        [HttpPost]
        public async Task<ActionResult<Miembro>> PostMiembro(Miembro miembro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Asignamos la fecha de registro si no se asignó
            if (miembro.FechaRegistro == default)
            {
                miembro.FechaRegistro = DateTime.Now;
            }

            _context.Miembros.Add(miembro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMiembro), new { id = miembro.Id }, miembro);
        }

        // PUT: api/Miembros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiembro(int id, Miembro miembro)
        {
            if (id != miembro.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(miembro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiembroExists(id))
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

        // DELETE: api/Miembros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiembro(int id)
        {
            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro == null)
            {
                return NotFound();
            }

            _context.Miembros.Remove(miembro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiembroExists(int id)
        {
            return _context.Miembros.Any(e => e.Id == id);
        }
    }
}
