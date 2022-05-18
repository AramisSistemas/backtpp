using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class OpPuerto
    {
        public OpPuerto()
        {
            Esquemas = new HashSet<Esquema>();
            OpEmpleados = new HashSet<OpEmpleado>();
        }

        public int Id { get; set; }
        public string Detalle { get; set; } = null!;

        public virtual ICollection<Esquema> Esquemas { get; set; }
        public virtual ICollection<OpEmpleado> OpEmpleados { get; set; }
    }
}
