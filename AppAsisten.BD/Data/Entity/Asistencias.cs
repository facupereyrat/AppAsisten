namespace AppAsisten.BD.Data.Entity
{
    public class Asistencia : EntityBase
    {
        public int MiembroId { get; set; }
        public Miembro? Miembro { get; set; }
        public string? CodigoQR { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Salida { get; set; }
    }
}
