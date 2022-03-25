﻿using Repository.Modelsdto.Commons;

namespace Repository.Modelsdto.Operations
{
    public class LiquidacionesByOp
    {
        public IEnumerable<OperationModel> OperationModel { get; set; }
        public IEnumerable<OperacionManiobraModel> OperacionManiobra { get; set; }
        public IEnumerable<LiquidacionModel> LiquidacionModel { get; set; }
        public IEnumerable<LiquidacionDetalleModel> LiquidacionDetalleModel { get; set; }
        public IEnumerable<EmpresaDto> EmpresaDtos { get; set; }
    }
}
