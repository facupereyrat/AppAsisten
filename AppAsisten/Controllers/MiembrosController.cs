using AppAsisten.BD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppAsisten.BD.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAsisten.Controllers
{
    [ApiController]
    [Route("api/Miembros")]
    public class MiembrosController : ControllerBase
    {
        private readonly Context context;

        public MiembrosController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Miembro>>> GetMiembros()
        {
            return await context.Miembros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Miembro>> GetMiembro(int id)
        {
            var miembro = await context.Miembros.FindAsync(id);

            if (miembro == null)
            {
                return NotFound();
            }

            return miembro;
        }

        [HttpPost]
        public async Task<ActionResult<Miembro>> PostMiembro(Miembro miembro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Miembros.Add(miembro);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMiembro), new { id = miembro.Id }, miembro);
        }

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

            context.Entry(miembro).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiembroExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiembro(int id)
        {
            var miembro = await context.Miembros.FindAsync(id);
            if (miembro == null)
            {
                return NotFound();
            }

            context.Miembros.Remove(miembro);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiembroExists(int id)
        {
            return context.Miembros.Any(e => e.Id == id);
        }
    }
}
