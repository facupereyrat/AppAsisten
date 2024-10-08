using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAsisten.BD.Data.Entity
{
    public class Asistencia : EntityBase
    {
        public int MiembroId { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public Miembro Miembro { get; set; } 
    }
}
