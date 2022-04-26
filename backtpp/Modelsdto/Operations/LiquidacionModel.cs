namespace backtpp.Modelsdtos.Operations
{
    public class LiquidacionModel
    {
        public long Liquidacion { get; set; }
        public long Maniobra { get; set; }
        public long IdEmpleado { get; set; }
        public long Cuit { get; set; }
        public string Nombre { get; set; }
        public int IdPuesto { get; set; }
        public string Puesto { get; set; }
        public decimal Llave { get; set; }
        public decimal Haberes { get; set; }
        public decimal Descuentos { get; set; }
        public decimal Remunerativos { get; set; }
        public decimal NoRemunerativos { get; set; }
        public decimal Neto { get; set; }
        public string EnLetras { get; set; }
        public string Cbu { get; set; }

        // Para Pays
        public DateTime Fecha { get; set; }
        public string Turno { get; set; }
        public string Destino { get; set; }
    }
}
