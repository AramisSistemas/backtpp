namespace backtpp.Models
{
    public partial class OpPuesto
    {
        public OpPuesto()
        {
            Liquidacions = new HashSet<Liquidacion>();
            OpComposicions = new HashSet<OpComposicion>();
            OpDetalleLiquidacionSacs = new HashSet<OpDetalleLiquidacionSac>();
            OpDetalleLiquidacions = new HashSet<OpDetalleLiquidacion>();
        }

        public int Id { get; set; }
        public string Detalle { get; set; } = null!;
        public int Agrupacion { get; set; }

        public virtual OpAgrupacion AgrupacionNavigation { get; set; } = null!;
        public virtual ICollection<Liquidacion> Liquidacions { get; set; }
        public virtual ICollection<OpComposicion> OpComposicions { get; set; }
        public virtual ICollection<OpDetalleLiquidacionSac> OpDetalleLiquidacionSacs { get; set; }
        public virtual ICollection<OpDetalleLiquidacion> OpDetalleLiquidacions { get; set; }
    }
}
