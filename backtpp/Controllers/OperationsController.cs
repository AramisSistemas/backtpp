using AutoMapper;
using backtpp.Helpers;
using backtpp.Interfaces;
using backtpp.Models;
using backtpp.Modelsdto.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backtpp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _operationService;
        private readonly IGenericService<OperacionManiobra> _genericOperacionManiobraService;
        private readonly ILoggService _loggService;
        private readonly IMapper _mapper;
        private readonly SecurityService _securityService;
        private readonly string _userName;
        private readonly int _userPerfil;

        public OperationsController(IOperationService operationService, ILoggService loggService, IGenericService<OperacionManiobra> genericOperacionManiobraService, IMapper mapper, SecurityService securityService)
        {
            _operationService = operationService;
            _loggService = loggService;
            _genericOperacionManiobraService = genericOperacionManiobraService;
            _mapper = mapper;
            _securityService = securityService;
            _userName = _securityService.GetUserAuthenticated();
            _userPerfil = _securityService.GetPerfilAuthenticated();
        }

        [HttpGet]
        public IActionResult GetAll(bool activas)
        {
            IEnumerable<OperationModel>? data = _operationService.GetAll(!activas);

            return Ok(data);
        }

        [HttpGet]
        [Route("GetManiobrasActivas")]
        public IActionResult GetManiobrasActivas(bool? finalizada)
        {
            IEnumerable<ManiobraModel>? data = _operationService.GetManiobrasActivas(finalizada);
            return Ok(data);
        }

        [HttpPut]
        [Route("AddManiobraOperacion")]
        public IActionResult AddManiobraOperacion([FromForm] ManiobraModel maniobraModel)
        {
            try
            {
                OperacionManiobra? maniobra = _mapper.Map<OperacionManiobra>(maniobraModel);
                _operationService.AddManiobraOperacion(maniobra);
                _loggService.Log("Maniobra Ingresada", "Maniobras", "Add", _userName);
                return Ok();
            }
            catch (Exception ex)
            {
                _loggService.Log("Error tratando de Ingresar Maniobra", "Maniobras", "Add", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdateManiobraOperacion")]
        public IActionResult UpdateManiobraOperacion([FromForm] ManiobraModel maniobraModel)
        {

            try
            {
                OperacionManiobra? maniobra = _mapper.Map<OperacionManiobra>(maniobraModel);
                _operationService.UpdateManiobraOperacion(maniobra);
                _loggService.Log($"Maniobra {maniobraModel.ManiobraNombre} Actualizada", "Maniobras", "Update", _userName);
                return Ok(new { message = "Maniobra Actualizada" });
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Actualizar Maniobra {maniobraModel.ManiobraNombre}", "Maniobras", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("ManiobrasFinalizar")]
        public IActionResult ManiobrasFinalizar(long maniobra)
        {

            try
            {
                _operationService.ManiobrasFinalizar(maniobra);
                _loggService.Log($"Maniobra {maniobra} Finalizada", "Maniobras", "Update", _userName);
                return Ok(new { message = "Maniobra Finalizada" });
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Finalizar Maniobra {maniobra}", "Maniobras", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteManiobraOperacion")]
        public IActionResult DeleteManiobraOperacion(long id)
        {
            try
            {
                _genericOperacionManiobraService.Delete(id);
                _loggService.Log($"Maniobra {id} Eliminada", "Maniobras", "Delete", _userName);
                return Ok(new { message = "Maniobra Eliminada" });
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Eliminar Maniobra  {id}", "Maniobras", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetComposicionByManiobra")]
        public IActionResult GetComposicionByManiobra(long id)
        {
            try
            {
                IEnumerable<ComposicionManiobraDto>? data = _operationService.GetComposicionByManiobra(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Obtener Composición Maniobra  {id}", "Maniobras", "Select", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetLiquidacionByManiobra")]
        public IActionResult GetLiquidacionByManiobra(long id, int puesto)
        {
            try
            {
                IEnumerable<LiquidacionByManiobraDto>? data = _operationService.GetLiquidacionByManiobra(id, puesto);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Obtener Liquidaciones por Maniobra  {puesto}", "Maniobras", "Select", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("LiquidacionesCerrarByOpByPuesto")]
        public IActionResult LiquidacionesCerrarByOpByPuesto(long operacion, int puesto)
        {
            try
            {
                bool res = _operationService.LiquidacionesCerrarByOpByPuesto(operacion, puesto, _userName);
                _loggService.Log($"Operación {operacion} Cerrada Correctamente", "Maniobras", "Cierre", _userName);
                return Ok("Maniobra Cerrada Correctamente");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Cerrar Operación  {operacion}", "Maniobras", "Cierre", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("LiquidacionesConfirmarByOpByPuesto")]
        public IActionResult LiquidacionesConfirmarByOpByPuesto(long operacion, int puesto)
        {
            try
            {
                bool res = _operationService.LiquidacionesConfirmarByOpByPuesto(operacion, puesto, _userName, _userPerfil);
                _loggService.Log($"Operación {operacion} Confirmada Correctamente", "Maniobras", "Cierre", _userName);
                return Ok("Maniobra Confirmada Correctamente");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Confirmar Operación  {operacion}", "Maniobras", "Cierre", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("LiquidacionesReabrirByOpByPuesto")]
        public IActionResult LiquidacionesReabrirByOpByPuesto(long operacion, int puesto)
        {
            try
            {
                bool res = _operationService.LiquidacionesReabrirByOpByPuesto(operacion, puesto, _userName);
                _loggService.Log($"Operación {operacion} Reabierta Correctamente", "Maniobras", "Apertura", _userName);
                return Ok("Maniobra Reabierta Correctamente");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Reabrir Operación  {operacion}", "Maniobras", "Apertura", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("LiquidacionesLLave")]
        public IActionResult LiquidacionesLLave(long operacion, int puesto, int llave)
        {
            try
            {
                bool res = _operationService.LiquidacionesLLave(operacion, puesto, llave);
                if (res)
                {
                    _loggService.Log($"Operación {operacion} : Aplica Llave de {llave} Correctamente", "Maniobras", "Update", _userName);
                    return Ok("Maniobra Actualizada Correctamente");

                }
                else
                {
                    _loggService.Log($"Error tratando de Aplicar Llave de {llave} en Operación  {operacion}", "Maniobras", "Update", _userName);
                    // return error message if there was an exception
                    return BadRequest(new { message = "Verifique, no se aplicó la llave" });
                }


            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Aplicar Llave de {llave} en Operación  {operacion}", "Maniobras", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("LiquidacionesByOp")]
        public IActionResult LiquidacionesByOp(long operacion)
        {
            LiquidacionesByOp? data = _operationService.LiquidacionesByOp(operacion);
            return Ok(data);
        }

        [HttpGet]
        [Route("LiquidacionesPayPending")]
        public IActionResult LiquidacionesPayPending()
        {
            LiquidacionesByOp? data = _operationService.LiquidacionesPayPending();
            return Ok(data);
        }

        [HttpPost]
        [Route("LiquidacionesPay")]
        public IActionResult LiquidacionesPay([FromBody] List<LiquidacionPay> liquidacionPays)
        {

            try
            {
                IEnumerable<LiquidacionesLotePago>? data = _operationService.LiquidacionesPay(liquidacionPays);
                _loggService.Log($"Lote {data.First().Lote} Pagado. Cantidad {data.First().Cantidad}", "Pays", "Update", _userName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratanto de realizar Pagos", "Pays", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("LiquidacionesAdd")]
        public IActionResult LiquidacionesAdd([FromBody] List<LiquidacionInsert> liquidacionInserts)
        {
            foreach (LiquidacionInsert? item in liquidacionInserts)
            {
                item.Operador = _userName;
            }
            try
            {
                bool data = _operationService.LiquidacionesAdd(liquidacionInserts);
                _loggService.Log("Liquidaciones Agregadas", "Liquidaciones", "Add", _userName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log("Error tratando de Agregar Liquidaciones", "Liquidaciones", "Add", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("LiquidacionesDelete")]
        public IActionResult LiquidacionesDelete(long operacion, int puesto)
        {
            try
            {
                bool data = _operationService.LiquidacionesDelete(operacion, puesto);
                _loggService.Log($"Liquidaciones Eliminadas en Operacion {operacion} Puesto {puesto}", "Liquidaciones", "Delete", _userName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratanto de eliminar Liquidaciones en Operacion {operacion} Puesto {puesto}", "Liquidaciones", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("LiquidacionesDeleteByLiq")]
        public IActionResult LiquidacionesDeleteByLiq(long liquidacion)
        {
            try
            {
                bool data = _operationService.LiquidacionesDelete(liquidacion);
                _loggService.Log($"Liquidacion {liquidacion} Eliminada", "Liquidaciones", "Delete", _userName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratanto de eliminar Liquidación {liquidacion}", "Liquidaciones", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("SacLiquida")]
        public IActionResult SacLiquida(int semestre, int año)
        {
            try
            {
                bool res = _operationService.SacLiquida(semestre, año, _userName);
                _loggService.Log($"SAC {semestre}ª del {año} Liquidado Correctamente", "Liquidaciones", "Cierre", _userName);
                return Ok("SAC Liquidado");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Liquidar SAC {semestre}ª del {año}", "Liquidaciones", "Cierre", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("SacConfirma")]
        public IActionResult SacConfirma(int semestre, int año)
        {
            try
            {
                bool res = _operationService.SacConfirma(semestre, año, _userName);
                _loggService.Log($"SAC {semestre}ª del {año} Confirmado Correctamente", "Liquidaciones", "Confirm", _userName);
                return Ok("SAC Confirmado");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Confirmar SAC {semestre}ª del {año}", "Liquidaciones", "Confirm", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpDelete]
        [Route("SacDelete")]
        public IActionResult SacDelete(int semestre, int año)
        {
            try
            {
                bool data = _operationService.SacDelete(semestre, año);
                _loggService.Log($"Liquidaciones Eliminadas SAC {semestre}ª del {año}", "Liquidaciones", "Delete", _userName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratanto de eliminar Liquidaciones SAC {semestre}ª del {año}", "Liquidaciones", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("SacReabre")]
        public IActionResult SacReabre(int semestre, int año)
        {
            try
            {
                bool res = _operationService.SacReabre(semestre, año, _userName);
                _loggService.Log($"SAC {semestre}ª del {año} Reabierto Correctamente", "Liquidaciones", "Cierre", _userName);
                return Ok("SAC Liquidado");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Reabrir SAC {semestre}ª del {año}", "Liquidaciones", "Cierre", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("SacPay")]
        public IActionResult SacPay([FromBody] List<LiquidacionPay> liquidacionPays)
        {

            try
            {
                IEnumerable<LiquidacionesLotePago>? data = _operationService.SacPay(liquidacionPays);
                _loggService.Log($"Lote {data.First().Lote} Pagado. Cantidad {data.First().Cantidad}", "Pays", "Update", _userName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratanto de realizar Pagos", "Pays", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        #region Auxiliares
        [HttpGet]
        [Route("GetTurnos")]
        public IActionResult GetTurnos(int esquema)
        {
            IEnumerable<Turno>? turnos = _operationService.GetTurnoByEsquema(esquema);
            List<TurnoModel>? data = _mapper.Map<List<TurnoModel>>(turnos);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetManiobras")]
        public IActionResult GetManiobras()
        {
            IEnumerable<OpManiobra>? data = _operationService.GetManiobrasAll();
            return Ok(data);
        }

        #endregion
    }
}
