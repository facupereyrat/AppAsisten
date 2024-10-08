using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppAsisten.BD.Data;
using AppAsisten.BD.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAsisten.Controllers
{
    [ApiController]
    [Route("api/Cuotas")]
    public class CuotasController : ControllerBase
    {
        private readonly Context context;

        public CuotasController(Context context)
        {
            this.context = context;
        }

        // Revisa cuotas incluyendo miembros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuota>>> GetCuotas()
        {
            return await context.Cuotas.Include(c => c.Miembro).ToListAsync();
        }

        // Cuota segun id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuota>> GetCuota(int id)
        {
            var cuota = await context.Cuotas.Include(c => c.Miembro).MinAsync();

            if (cuota == null)
            {
                return NotFound();
            }

            return cuota;
        }

        // Agrega cuota y retorna su creacion
        [HttpPost]
        public async Task<ActionResult<Cuota>> PostCuota(Cuota cuota)
        {
            context.Cuotas.Add(cuota);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCuota), new { id = cuota.Id }, cuota);
        }

        // Revisa la coincidencia de cuota con parametro id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuota(int id, Cuota cuota)
        {
            if (id != cuota.Id)
            {
                return BadRequest();
            }
            //Marca cuota modif
            context.Entry(cuota).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuotaExists(id))
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

        // Elimina cuota
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuota(int id)
        {
            var cuota = await context.Cuotas.FindAsync(id);
            if (cuota == null)
            {
                return NotFound();
            }

            context.Cuotas.Remove(cuota);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuotaExists(int id)
        {
            return context.Cuotas.Any(e => e.Id == id);
        }
    }
}
