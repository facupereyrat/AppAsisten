using System;

namespace AppAsisten.BD.Data.Entity
{
    public class Asistencia : EntityBase
    {
        public int MiembroId { get; set; }  // Relación con Miembro
        public DateTime Entrada { get; set; }  // Fecha y hora de entrada
        public DateTime? Salida { get; set; }  // Fecha y hora de salida (opcional, ya que puede no haberse registrado aún)

        public Miembro Miembro { get; set; }  // Relación de navegación
    }
}
