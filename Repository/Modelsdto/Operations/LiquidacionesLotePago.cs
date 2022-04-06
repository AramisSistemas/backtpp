using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modelsdto.Operations
{
    public class LiquidacionesLotePago
    {
        public string Cuit { get; set; }
        public long Lote { get; set; }
        public int Cantidad { get; set; }
    }
}
