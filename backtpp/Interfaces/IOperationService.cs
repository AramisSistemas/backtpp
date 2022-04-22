using backtpp.Models;
using backtpp.Modelsdto.Operations;

namespace backtpp.Interfaces
{
    public interface IOperationService
    {
        IEnumerable<OperationModel> GetAll(bool? finalizada = false);
        IEnumerable<ManiobraModel> GetManiobrasActivas(bool? finalizada = false);
        IEnumerable<Turno> GetTurnoByEsquema(int esquema);
        IEnumerable<OpManiobra> GetManiobrasAll();
        IEnumerable<ComposicionManiobraDto> GetComposicionByManiobra(long id);
        IEnumerable<LiquidacionByManiobraDto> GetLiquidacionByManiobra(long op, int puesto);
        Operacion Add(Operacion operacion);
        bool AddManiobraOperacion(OperacionManiobra operacionManiobra);
        bool ManiobrasFinalizar(long operacion);
        bool UpdateManiobraOperacion(OperacionManiobra operacionManiobra);
        bool LiquidacionesCerrarByOpByPuesto(long operacion, int puesto, string operador);
        bool LiquidacionesConfirmarByOpByPuesto(long operacion, int puesto, string operador, int perfil);
        bool LiquidacionesReabrirByOpByPuesto(long operacion, int puesto, string operador);
        bool LiquidacionesAdd(List<LiquidacionInsert> liquidacion);
        bool LiquidacionesDelete(long operacion, int puesto);
        bool LiquidacionesDelete(long liquidacion);
        LiquidacionesByOp LiquidacionesByOp(long operacion);
        bool LiquidacionesLLave(long operacion, int puesto, int llave);
        LiquidacionesByOp LiquidacionesPayPending();
        IEnumerable<LiquidacionesLotePago> LiquidacionesPay(List<LiquidacionPay> liquidaciones);
        bool SacLiquida(int semestre, int año, string operador);
        bool SacConfirma(int semestre, int año, string operador);
        bool SacDelete(int semestre, int año);
        bool SacReabre(int semestre, int año, string operador);
        IEnumerable<LiquidacionesLotePago> SacPay(List<LiquidacionPay> liquidaciones);
        SacByPeriodo  GetSacByPeriodo(int? año=null);
    }
}

