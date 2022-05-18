namespace backtpp.Modelsdtos.Empleados
{
    public class EmpleadosDto
    {
        public long Id { get; set; }
        public long Cuil { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public int Ciudad { get; set; }
        public long? OSocial { get; set; }
        public DateTime Nacimiento { get; set; }
        public bool Conyuge { get; set; }
        public int Hijos { get; set; }
        public string Cbu { get; set; }
        public long CuilCbu { get; set; }
        public bool Activo { get; set; }
        public DateTime Ingreso { get; set; }
        public string Sexo { get; set; }
        public string ObraSocialDetalle { get; set; }
    }
}
