using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class Sac
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Semestre { get; set; }
        public int Año { get; set; }
        public bool Confirmada { get; set; }
        public bool Pagado { get; set; }
        public string Operador { get; set; } = null!;
        public string OperadorConfirma { get; set; } = null!;
        public string? Cbu { get; set; }
        public long Lote { get; set; }
        public long Empleado { get; set; }

        public virtual OpEmpleado EmpleadoNavigation { get; set; } = null!;
    }
}
