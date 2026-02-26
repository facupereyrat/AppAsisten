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

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] string codigoQR)
        {
            if (string.IsNullOrWhiteSpace(codigoQR))
                return BadRequest("Debe proporcionar un código QR.");

            var miembro = await context.Miembros
                .FirstOrDefaultAsync(m => m.CodigoQR == codigoQR);

            if (miembro == null)
                return BadRequest("Código QR no válido.");

            if (!miembro.EstaActivo)
                return BadRequest("El miembro no está activo.");

            // Buscar asistencia abierta (sin salida)
            var asistenciaAbierta = await context.Asistencias
                .Where(a => a.MiembroId == miembro.Id && a.Salida == null)
                .OrderByDescending(a => a.Entrada)
                .FirstOrDefaultAsync();

            bool fueEntrada;

            if (asistenciaAbierta == null)
            {
                // Registrar ENTRADA
                asistenciaAbierta = new Asistencia
                {
                    MiembroId = miembro.Id,
                    Entrada = DateTime.Now
                };

                context.Asistencias.Add(asistenciaAbierta);
                fueEntrada = true;
            }
            else
            {
                // Registrar SALIDA
                asistenciaAbierta.Salida = DateTime.Now;
                fueEntrada = false;
            }

            await context.SaveChangesAsync();

            var miembroDto = mapper.Map<MiembroDTO>(miembro);

            return Ok(new AsistenciaRespuestaDTO
            {
                Miembro = miembroDto,
                Entrada = asistenciaAbierta.Entrada,
                Salida = asistenciaAbierta.Salida,
                EsEntrada = fueEntrada
            });
        }
    }
}