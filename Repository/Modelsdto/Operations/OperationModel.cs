namespace Repository.Modelsdto.Operations
{
    public class OperationModel
    {
        public long Id { get; set; }
        public DateTime Inicio { get; set; }
        public string Destino { get; set; }
        public string Cliente { get; set; }
        public string Esquema { get; set; }
        public int IdEsquema { get; set; }
    }
}
