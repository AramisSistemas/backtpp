using backtpp.Modelsdto.Commons;

namespace backtpp.Modelsdto.Operations
{
    public class SacByPeriodo
    {
        public IEnumerable<SacPeriod> SacPeriods { get; set; }
        public IEnumerable<SacModel> SacModels { get; set; }
        public IEnumerable<LiquidacionDetalleModel> LiquidacionDetalleModel { get; set; }
        public IEnumerable<EmpresaDto> EmpresaDtos { get; set; }
    }
}
