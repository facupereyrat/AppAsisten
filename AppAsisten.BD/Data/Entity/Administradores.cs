using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAsisten.BD.Data.Entity
{
    public class Administrador : EntityBase
    {
        [Required(ErrorMessage = "El nombre del administrador es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del administrador es obligatorio.")]
        public string Apellido { get; set; }
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {30}.")]
        public string Email { get; set; }
        public ICollection<Cuota> Cuotas { get; set; }
        public ICollection<Asistencia> Asistencias { get; set; }
        public ICollection<Miembro> Miembros { get; set; }
    }
}
