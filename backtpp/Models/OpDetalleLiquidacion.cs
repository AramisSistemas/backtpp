using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class OpDetalleLiquidacion
    {
        public long Id { get; set; }
        public long ManiobraOpFk { get; set; }
        public int PuestoFk { get; set; }
        public string Codigo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
        public bool Haber { get; set; }
        public bool Remunerativo { get; set; }
        public bool Fijo { get; set; }
        public long Empleado { get; set; }
        public long IdEmbargos { get; set; }

        public virtual OperacionManiobra ManiobraOpFkNavigation { get; set; } = null!;
        public virtual OpPuesto PuestoFkNavigation { get; set; } = null!;
    }
}
