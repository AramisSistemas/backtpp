using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Liquidacion
    {
        public long Id { get; set; }
        public long Empleado { get; set; }
        public long Operacion { get; set; }
        public int Puesto { get; set; }
        public decimal Llave { get; set; }
        public bool Abierta { get; set; }
        public bool Confirmada { get; set; }
        public bool Pagado { get; set; }
        public string? Operador { get; set; }
        public string? OperadorConfirma { get; set; }
        public string? Cbu { get; set; }

        public virtual OpEmpleado EmpleadoNavigation { get; set; } = null!;
        public virtual OperacionManiobra OperacionNavigation { get; set; } = null!;
        public virtual OpPuesto PuestoNavigation { get; set; } = null!;
    }
}
