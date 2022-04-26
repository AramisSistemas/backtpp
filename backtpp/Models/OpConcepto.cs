namespace backtpp.Models
{
    public partial class OpConcepto
    {
        public long Id { get; set; }
        public int Agrupacion { get; set; }
        public string Codigo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Monto { get; set; }
        public bool Fijo { get; set; }
        public bool Haber { get; set; }
        public bool Remunerativo { get; set; }
        public bool Sbasico { get; set; }
        public bool Sbruto { get; set; }
        public bool Sremun { get; set; }
        public bool Obligatorio { get; set; }

        public virtual OpAgrupacion AgrupacionNavigation { get; set; } = null!;
    }
}
