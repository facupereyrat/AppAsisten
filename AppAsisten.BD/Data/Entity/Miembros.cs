using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppAsisten.BD.Data.Entity
{
    public class Miembro : EntityBase
    {
        [Required(ErrorMessage = "El nombre del miembro es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del miembro es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El código del miembro es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El código no puede superar los 100 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
        public DateTime FechaRegistro { get; set; }

        public bool EsActivo { get; set; }

        // Relación de un miembro con varias asistencias
        public ICollection<Asistencia> Asistencias { get; set; }

        // Constructor para inicializar colecciones
        public Miembro()
        {
            Asistencias = new List<Asistencia>();
        }
    }
}
