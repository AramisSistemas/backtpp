using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class OpManiobra
    {
        public OpManiobra()
        {
            OpComposicions = new HashSet<OpComposicion>();
            OperacionManiobras = new HashSet<OperacionManiobra>();
        }

        public int Id { get; set; }
        public string Detalle { get; set; } = null!;

        public virtual ICollection<OpComposicion> OpComposicions { get; set; }
        public virtual ICollection<OperacionManiobra> OperacionManiobras { get; set; }
    }
}
