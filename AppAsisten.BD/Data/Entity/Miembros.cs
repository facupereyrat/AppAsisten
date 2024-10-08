using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAsisten.BD.Data.Entity
{
    public class Miembro : EntityBase
    {
        [Required(ErrorMessage = "El nombre del tipo del miembro es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del miembro es obligatorio.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El apellido del miembro es obligatorio.")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El codigo es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {4}.")]
        public DateTime FechaRegistro { get; set; }
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {6}.")]
        public bool EsActivo { get; set; }
        public ICollection<Asistencia> Asistencias { get; set; }
        public ICollection<Cuota> Cuotas { get; set; }
    }
}
