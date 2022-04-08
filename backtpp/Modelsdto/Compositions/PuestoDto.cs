namespace backtpp.Modelsdto.Compositions
{
    public class PuestoDto
    {
        public int Id { get; set; }
        public string Detalle { get; set; } = null!;
        public int Agrupacion { get; set; }
        public string AgrupacionStr { get; set; } = null!;
    }
}
