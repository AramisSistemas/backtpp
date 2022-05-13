namespace backtpp.Modelsdto.Customers
{
    public class CustomerAdd
    { 
        public long Cuit { get; set; }
        public string Responsabilidad { get; set; } 
        public string Genero { get; set; } 
        public string Imputacion { get; set; } 
        public string Nombre { get; set; }   
        public string Domicilio { get; set; } 
        public string Telefono { get; set; } 
        public string? Mail { get; set; }
        public decimal LimiteSaldo { get; set; }
        public string? Observaciones { get; set; } 
    }
}
