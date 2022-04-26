namespace backtpp.Modelsdto.Operations
{
    public class SacModel
    {
        public long Liquidacion { get; set; }
        public DateTime Fecha { get; set; }
        public long Empleado { get; set; }
        public string Cuil { get; set; }
        public string Cbu { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }
        public int Semestre { get; set; }
        public bool Confirmada { get; set; }
        public bool Pagado { get; set; }
        public string Operador { get; set; }
        public string OperadorConfirma { get; set; }
        public decimal Haberes { get; set; }
        public decimal Descuentos { get; set; }
        public decimal Remunerativos { get; set; }
        public decimal NoRemunerativos { get; set; }
        public decimal Neto { get; set; }
        public string EnLetras { get; set; }
    }
}
