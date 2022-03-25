using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modelsdto.Operations
{
    public class LiquidacionDetalleModel
    {
        public long Liquidacion { get; set; }
        public long Maniobra { get; set; }
        public int Puesto { get; set; } 
        public string Codigo { get; set; }
        public string Concepto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
        public bool Haber { get; set; }
        public bool Remunerativo { get; set; }
        public long IdEmpleado { get; set; }
    }
}
