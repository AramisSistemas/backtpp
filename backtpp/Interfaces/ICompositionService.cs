using backtpp.Modelsdtos.Compositions;

namespace backtpp.Interfaces
{
    public interface ICompositionService
    {
        IEnumerable<CompositionDto> GetAll();
        IEnumerable<CompositionJornales> GetCompoJornalesUso(int agrupacion);
        IEnumerable<PuestoDto> GetPuestos();
        bool ComposicionJornalesInsert(List<CompositionJornales> compositionJornales);
    }
}
