using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modelsdto.Compositions
{
    public class CompositionDto
    {
        public long Id { get; set; }
        public int Maniobra { get; set; }
        public string ManiobraStr { get; set; }
        public int Esquema { get; set; }
        public string EsquemaStr { get; set; }
        public int Puesto { get; set; }
        public string PuestoStr { get; set; }
        public int Cantidad { get; set; }
    }
}
