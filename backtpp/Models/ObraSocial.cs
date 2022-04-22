using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class ObraSocial
    {
        public ObraSocial()
        {
            OpEmpleados = new HashSet<OpEmpleado>();
        }

        public long Id { get; set; }
        public string Detalle { get; set; } = null!;

        public virtual ICollection<OpEmpleado> OpEmpleados { get; set; }
    }
}
