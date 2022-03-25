namespace Repository.Modelsdto.Operations
{
    public class LiquidacionByManiobraDto
    {
        public long Operacion { get; set; }

        public int Turno { get; set; }

        public string? Horario { get; set; }

        public DateTime Fecha { get; set; }

        public string? Puesto { get; set; }

        public int IdPuesto { get; set; }

        public long? Liquidacion { get; set; }

        public long? IdEmpleado { get; set; }

        public long? Empleado { get; set; }

        public string? Nombre { get; set; }

        public string? Tipo { get; set; }

        public string? Color { get; set; }

        public bool Abierta { get; set; }
        public bool Confirmada { get; set; }
        public bool Pagado { get; set; }
        public decimal Llave { get; set; }

    }
}
