using AppAsisten.BD.Data;
using AppAsisten.BD.Data.Entity;
using AppAsisten.Shared.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AppAsisten.Controllers
{
    [Route("api/Asistencia")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public AsistenciaController(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // Registrar Entrada
        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] string codigoQR)
        {
            var miembro = await context.Miembros
                .FirstOrDefaultAsync(m => m.CodigoQR == codigoQR);

            if (miembro == null)
            {
                return BadRequest("Código QR no válido.");
            }

            var asistencia = new Asistencia
            {
                MiembroId = miembro.Id,
                Entrada = DateTime.Now
            };

            context.Asistencias.Add(asistencia);
            await context.SaveChangesAsync();

            // Devolver tanto la asistencia como los detalles del miembro
            var miembroDto = mapper.Map<MiembroDTO>(miembro);
            var asistenciaDto = mapper.Map<AsistenciaDTO>(asistencia);

            return Ok(new { Asistencia = asistenciaDto, Miembro = miembroDto });
        }

        // Registrar Salida
        [HttpPost("salida")]
        public async Task<IActionResult> RegistrarSalida([FromBody] string codigoQR)
        {
            var miembro = await context.Miembros
                .FirstOrDefaultAsync(m => m.CodigoQR == codigoQR);

            if (miembro == null)
            {
                return BadRequest("Código QR no válido.");
            }

            var asistencia = await context.Asistencias
                .Where(a => a.Miembro.CodigoQR == codigoQR)
                .OrderByDescending(a => a.Entrada)   
                .LastOrDefaultAsync();


            if (asistencia == null)
            {
                return BadRequest("No se ha registrado una entrada para este miembro.");
            }

            asistencia.Salida = DateTime.Now;
            await context.SaveChangesAsync();

            // Devolver tanto la asistencia como los detalles del miembro
            var miembroDto = mapper.Map<MiembroDTO>(miembro);
            var asistenciaDto = mapper.Map<AsistenciaDTO>(asistencia);

            return Ok(new { Asistencia = asistenciaDto, Miembro = miembroDto });
        }
    }
}

