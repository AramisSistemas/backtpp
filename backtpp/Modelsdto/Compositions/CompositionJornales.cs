namespace backtpp.Modelsdtos.Compositions
{
    public class CompositionJornales
    {
        public int Id { get; set; }
        public int Agrupacion { get; set; }
        public string Codigo { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public bool Fijo { get; set; }
        public bool Haber { get; set; }
        public bool Remunerativo { get; set; }
        public bool Sbasico { get; set; }
        public bool Sbruto { get; set; }
        public bool Sremun { get; set; }
        public bool Obligatorio { get; set; }

    }
}
