namespace backtpp.Models
{
    public partial class OpComposicion
    {
        public long Id { get; set; }
        public int Maniobra { get; set; }
        public int Esquema { get; set; }
        public int Puesto { get; set; }
        public int Cantidad { get; set; }

        public virtual Esquema EsquemaNavigation { get; set; } = null!;
        public virtual OpManiobra ManiobraNavigation { get; set; } = null!;
        public virtual OpPuesto PuestoNavigation { get; set; } = null!;
    }
}
