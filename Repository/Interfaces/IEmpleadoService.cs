using Repository.Modelsdto.Empleados;

namespace Repository.Interfaces
{
    public interface IEmpleadoService
    {
        IEnumerable<EmpleadosDto> GetAll(bool? activo);


    }
}
