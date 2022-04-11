using backtpp.Modelsdto.Compositions;

namespace backtpp.Interfaces
{
    public interface ICompositionService
    {
        IEnumerable<CompositionDto> GetAll();
        IEnumerable<PuestoDto> GetPuestos();
    }
}
