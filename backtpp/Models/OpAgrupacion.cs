namespace backtpp.Models
{
    public partial class OpAgrupacion
    {
        public OpAgrupacion()
        {
            OpConceptos = new HashSet<OpConcepto>();
            OpPuestos = new HashSet<OpPuesto>();
        }

        public int Id { get; set; }
        public string Detalle { get; set; } = null!;

        public virtual ICollection<OpConcepto> OpConceptos { get; set; }
        public virtual ICollection<OpPuesto> OpPuestos { get; set; }
    }
}
