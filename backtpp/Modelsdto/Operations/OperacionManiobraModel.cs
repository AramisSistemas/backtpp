namespace backtpp.Modelsdto.Operations
{
    public class OperacionManiobraModel
    {

        public long IdManiobra { get; set; }
        public long Operacion { get; set; }
        public string Horario { get; set; }
        public string Maniobra { get; set; }
        public decimal Produccion { get; set; }
        public bool Lluvia { get; set; }
        public bool Sobrepeso { get; set; }
        public bool Insalubre { get; set; }
        public DateTime Fecha { get; set; }
    }
}
