using AppAsisten.BD.Data;
using AppAsisten.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppAsisten.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciasController : ControllerBase
    {
        private readonly Context _context;

        public AsistenciasController(Context context)
        {
            _context = context;
        }

        // POST: api/Asistencias
        [HttpPost]
        public async Task<ActionResult<Asistencia>> PostAsistencia(Asistencia asistencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el miembro existe
            var miembro = await _context.Miembros.FindAsync(asistencia.MiembroId);
            if (miembro == null)
            {
                return NotFound("Miembro no encontrado.");
            }

            // Registrar entrada (si no se ha hecho)
            if (asistencia.Entrada == default)
            {
                asistencia.Entrada = DateTime.Now;
            }

            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();

            // Devolver la URL del recurso creado
            return CreatedAtAction(nameof(GetAsistencia), new { id = asistencia.Id }, asistencia);
        }

        // GET: api/Asistencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asistencia>> GetAsistencia(int id)
        {
            var asistencia = await _context.Asistencias
                .Include(a => a.Miembro)  // Incluir información del miembro
                .FirstOrDefaultAsync(a => a.Id == id);

            if (asistencia == null)
            {
                return NotFound();
            }

            return asistencia;
        }

        // PUT: api/Asistencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistencia(int id, Asistencia asistencia)
        {
            if (id != asistencia.Id)
            {
                return BadRequest();
            }

            var asistenciaExistente = await _context.Asistencias.FindAsync(id);
            if (asistenciaExistente == null)
            {
                return NotFound();
            }

            // Registrar salida
            if (asistenciaExistente.Salida == null && asistencia.Salida.HasValue)
            {
                asistenciaExistente.Salida = DateTime.Now;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
