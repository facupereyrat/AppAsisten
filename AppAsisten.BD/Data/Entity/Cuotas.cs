using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAsisten.BD.Data.Entity
{
    public class Cuota : EntityBase
    {
        public int MiembroId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public bool EsPagada { get; set; }
        public Miembro Miembro { get; set; }
    }
}
