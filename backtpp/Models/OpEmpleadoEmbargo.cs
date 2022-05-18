using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class OpEmpleadoEmbargo
    {
        public long Id { get; set; }
        public long EmpleadoFk { get; set; }
        public decimal Monto { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
        public DateTime Fin { get; set; }
        public string Concepto { get; set; } = null!;
        public string? Operador { get; set; }
        public bool Anticipo { get; set; }

        public virtual OpEmpleado EmpleadoFkNavigation { get; set; } = null!;
    }
}
