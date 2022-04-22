namespace backtpp.Modelsdto.Operations
{
    public class LiquidacionDetalleModel
    {
        public long Liquidacion { get; set; }
        public long Maniobra { get; set; }
        public int Puesto { get; set; }
        public string Codigo { get; set; }
        public string Concepto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
        public bool Haber { get; set; }
        public bool Remunerativo { get; set; }
        public long IdEmpleado { get; set; } 

    }
}
