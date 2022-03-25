namespace Repository.Modelsdto.Empleados
{
    public class EmpleadosDto
    {
        public long Id { get; set; }
        public long Cuil { get; set; }
        public string Nombre { get; set; }
        public int? Puesto { get; set; }
        public string? PuestoDetalle { get; set; }
    }
}
