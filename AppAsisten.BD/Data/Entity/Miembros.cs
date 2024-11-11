namespace AppAsisten.BD.Data.Entity
{
    public class Miembro : EntityBase
    {
        public string? Nombre { get; set; }
        public string? CodigoQR { get; set; } 
        public bool EstaActivo { get; set; }
        public List<Asistencia> Asistencias { get; set; }
    }
}

