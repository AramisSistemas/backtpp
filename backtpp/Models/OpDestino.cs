using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class OpDestino
    {
        public OpDestino()
        {
            Operacions = new HashSet<Operacion>();
        }

        public int Id { get; set; }
        public string Detalle { get; set; } = null!;
        public string? Observaciones { get; set; }

        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}
