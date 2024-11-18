using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAsisten.Shared.DTO
{
    public class AsistenciaRespuestaDTO
    {
        public int MiembroId { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public AsistenciaRespuestaDTO Asistencia { get; set; }
        public MiembroDTO Miembro { get; set; }
    }
}
