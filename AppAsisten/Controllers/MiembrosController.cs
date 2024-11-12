using AppAsisten.BD.Data.Entity;
using AppAsisten.BD.Data;
using AppAsisten.Shared.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAsisten.Controllers
{
    [Route("api/Miembro")]
    [ApiController]
    public class MiembroController : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public MiembroController(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // Endpoint para crear un nuevo miembro
        [HttpPost("registrar-miembro")]
        public async Task<IActionResult> RegistrarMiembro([FromBody] MiembroDTO miembroDTO)
        {
            if (await context.Miembros.AnyAsync(m => m.CodigoQR == miembroDTO.CodigoQR))
            {
                return BadRequest("Ya existe un miembro con este código QR.");
            }

            var miembro = mapper.Map<Miembro>(miembroDTO);
            context.Miembros.Add(miembro);
            await context.SaveChangesAsync();

            var result = mapper.Map<MiembroDTO>(miembro);
            return Ok(result);
        }

        // Otros métodos aquí...
    }
}
