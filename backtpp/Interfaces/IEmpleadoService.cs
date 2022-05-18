using backtpp.Models;
using backtpp.Modelsdtos.Empleados;

namespace backtpp.Interfaces
{
    public interface IEmpleadoService
    {
        IEnumerable<EmpleadosDto> GetAll(bool? activo, int? puerto);
        bool Add(EmpleadosAdd empleado);
        bool Update(OpEmpleado empleado);
        void Delete(long id);
        bool EmbargoAdd(EmpleadoEmbargoAdd empleadoEmbargoAdd);
        bool EmbargoConfirm(long embargo, string operador);
        bool EmbargoDelete(long embargo);
        IEnumerable<EmbargosDto> EmbargosGet();

    }
}
