using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppAsisten.BD.Data;
using AppAsisten.BD.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAsisten.Controllers
{
    [ApiController]
    [Route("api/Administradores")]
    public class AdministradoresController : ControllerBase
    {
        private readonly Context context;

        public AdministradoresController(Context context)
        {
            this.context = context;
        }

        // Obtener todos los administradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradores()
        {
            return await context.Administradores.ToListAsync();
        }

        // Obtener administrador por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var administrador = await context.Administradores.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // Crear nuevo administrador
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Administradores.Add(administrador);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrador", new { id = administrador.Id }, administrador);
        }

        // Actualizar un administrador existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador administrador)
        {
            if (id != administrador.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // Eliminar administrador
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var administrador = await context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            context.Administradores.Remove(administrador);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return context.Administradores.Any(e => e.Id == id);
        }
    }
}

