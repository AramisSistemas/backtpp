using backtpp.Modelsdtos.Commons;

namespace backtpp.Modelsdtos.Operations
{
    public class LiquidacionesByOp
    {
        public IEnumerable<OperationModel> OperationModel { get; set; }
        public IEnumerable<OperacionManiobraModel> OperacionManiobra { get; set; }
        public IEnumerable<LiquidacionModel> LiquidacionModel { get; set; }
        public IEnumerable<LiquidacionDetalleModel> LiquidacionDetalleModel { get; set; }
        public IEnumerable<EmpresaDto> EmpresaDtos { get; set; }
        public IEnumerable<LiquidacionesPagos> LiquidacionesPagos { get; set; }
    }
}
