using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAsisten.Shared.DTO
{
    public class MiembroDTO
    {
        public int MiembroId { get; set; }  // ID único del miembro
        public string? CodigoQR { get; set; }  // Código QR único del miembro
        public string? Nombre { get; set; }  // Nombre del miembro
        public bool EstaActivo { get; set; }  // Indica si el miembro está activo o no
    }

}
