using AppAsisten.BD.Data.Entity;
using AppAsisten.BD.Data;
using AppAsisten.Shared.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    // Endpoint para obtener un miembro por su código QR
    [HttpGet("obtener-miembro/{codigoQR}")]
    public async Task<IActionResult> ObtenerMiembro(string codigoQR)
    {
        var miembro = await context.Miembros
            .FirstOrDefaultAsync(m => m.CodigoQR == codigoQR);

        if (miembro == null)
        {
            return NotFound("Miembro no encontrado.");
        }

        var miembroDTO = mapper.Map<MiembroDTO>(miembro);
        return Ok(miembroDTO);
    }

    // Endpoint para desactivar un miembro (por ejemplo, si está suspendido)
    [HttpPut("desactivar-miembro/{id}")]
    public async Task<IActionResult> DesactivarMiembro(int id)
    {
        var miembro = await context.Miembros.FindAsync(id);

        if (miembro == null)
        {
            return NotFound("Miembro no encontrado.");
        }

        miembro.EstaActivo = false;
        context.Miembros.Update(miembro);
        await context.SaveChangesAsync();

        return Ok();
    }
}
