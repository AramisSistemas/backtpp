namespace backtpp.Modelsdtos.Operations
{
    public class LiquidacionInsert
    {
        public long Empleado { get; set; }
        public long Operacion { get; set; }
        public int Puesto { get; set; }
        public bool Abierta { get; set; }
        public bool Pagado { get; set; }
        public string Operador { get; set; }
    }
}
