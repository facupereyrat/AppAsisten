using AppAsisten.BD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppAsisten.BD.Data.Entity; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAsisten.Controllers
{
    [ApiController]
    [Route("api/Asistencias")]
    public class AsistenciasController : ControllerBase
    {
        private readonly Context context; 

        public AsistenciasController(Context context)
        {
            this.context = context;
        }

        // Obtener todas las asisten
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asistencia>>> GetAsistencias()
        {
            return await context.Asistencias.Include(a => a.Miembro).ToListAsync();
        }

        // Asistencia por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Asistencia>> GetAsistencia(int id)
        {
            var asistencia = await context.Asistencias.Include(a => a.Miembro).MinAsync();

            if (asistencia == null)
            {
                return NotFound();
            }

            return asistencia;
        }

        // Metodo para crear asist
        [HttpPost]
        public async Task<ActionResult<Asistencia>> PostAsistencia(Asistencia asistencia)
        {
            context.Asistencias.Add(asistencia);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsistencia), new { id = asistencia.Id }, asistencia); 
        }

        // Actualizar asist existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistencia(int id, Asistencia asistencia)
        {
            if (id != asistencia.Id) 
            {
                return BadRequest();
            }

            context.Entry(asistencia).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsistenciaExists(id))
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

        // Eliminar asistencia por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistencia(int id)
        {
            var asistencia = await context.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }

            context.Asistencias.Remove(asistencia);
            await context.SaveChangesAsync(); //guarda cambios en bd

            return NoContent();
        }

        private bool AsistenciaExists(int id)
        {
            return context.Asistencias.Any(e => e.Id == id); 
        }
    }
}
