using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modelsdto.Operations
{
    public class LiquidacionesPagos
    {
        public long IdEmpleado { get; set; }
        public string Cuit { get; set; }
        public string Nombre { get; set; }
        public string Cbu { get; set; }
        public decimal Total { get; set; }
    }
}
