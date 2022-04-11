using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class OperacionManiobra
    {
        public OperacionManiobra()
        {
            Liquidacions = new HashSet<Liquidacion>();
            OpDetalleLiquidacions = new HashSet<OpDetalleLiquidacion>();
        }

        public long Id { get; set; }
        public long Operacion { get; set; }
        public int Turno { get; set; }
        public int Maniobra { get; set; }
        public decimal Produccion { get; set; }
        public bool Lluvia { get; set; }
        public bool Insalubre { get; set; }
        public bool Sobrepeso { get; set; }
        public DateTime Fecha { get; set; }
        public bool Finalizada { get; set; }

        public virtual OpManiobra ManiobraNavigation { get; set; } = null!;
        public virtual Operacion OperacionNavigation { get; set; } = null!;
        public virtual Turno TurnoNavigation { get; set; } = null!;
        public virtual ICollection<Liquidacion> Liquidacions { get; set; }
        public virtual ICollection<OpDetalleLiquidacion> OpDetalleLiquidacions { get; set; }
    }
}
