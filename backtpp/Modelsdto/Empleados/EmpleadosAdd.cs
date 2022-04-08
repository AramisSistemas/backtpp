namespace backtpp.Modelsdto.Empleados
{
    public class EmpleadosAdd
    {
        public long Cuil { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cbu { get; set; } = null!;
        public long? CuilCbu { get; set; }
        public string Sexo { get; set; }

    }
}
