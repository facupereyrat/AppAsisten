using AppAsisten.BD.Data.Entity;
using AppAsisten.BD.Data;
using AppAsisten.Shared.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OutputCaching;

namespace AppAsisten.Controllers
{
    [Route("api/Miembro")]
    [ApiController]
    public class MiembroController : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;
        private const string cacheKey = "TDocumentos";

        public MiembroController(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }



        [HttpGet]
        [OutputCache()]
        public async Task<ActionResult<IEnumerable<Miembro>>> GetMiembros()
        {
            var miembros = await context.Miembros.ToListAsync();
            if (miembros == null || !miembros.Any())
            {
                return NotFound("No se encontraron miembros registrados.");
            }
            return Ok(miembros);
        }

        // Endpoint para crear un nuevo miembro
        [HttpPost("registrar-miembro")]
        public async Task<IActionResult> RegistrarMiembro([FromBody] MiembroDTO miembroDTO)
        {
            await outputCacheStore.EvictByTagAsync(cacheKey, default);

            var miembro = mapper.Map<Miembro>(miembroDTO);

            // Generar automáticamente un código numérico de 6 dígitos
            var random = new Random();
            miembro.CodigoQR = random.Next(100000, 999999).ToString();

            context.Miembros.Add(miembro);
            await context.SaveChangesAsync();

            var result = mapper.Map<MiembroDTO>(miembro);
            return Ok(result);
        }

    }
}
