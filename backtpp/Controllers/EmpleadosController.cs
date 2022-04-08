using AutoMapper;
using backtpp.Helpers;
using backtpp.Interfaces;
using backtpp.Models;
using backtpp.Modelsdto.Empleados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backtpp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IGenericService<ObraSocial> _obraSocial;
        private readonly ILoggService _loggService;
        private readonly SecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly string _userName;
        public EmpleadosController(IEmpleadoService empleadoService, ILoggService loggService, SecurityService securityService, IMapper mapper, IGenericService<ObraSocial> obraSocial)
        {
            _securityService = securityService;
            _empleadoService = empleadoService;
            _obraSocial = obraSocial;
            _loggService = loggService;
            _userName = _securityService.GetUserAuthenticated();
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll(bool? activo)
        {
            IEnumerable<EmpleadosDto>? data = _empleadoService.GetAll(activo);
            return Ok(data);
        }

        [HttpPut]
        [Route("Add")]
        public IActionResult EmpleadosAdd([FromForm] EmpleadosAdd empleado)
        {
            try
            {
                _empleadoService.Add(empleado);
                _loggService.Log($"Alta de {empleado.Nombre}", "Empleados", "Insert", _userName);
                return Ok("Alta Correcta");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Ingresar a {empleado.Nombre}", "Empleados", "Insert", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult EmpleadosDelete(long id)
        {
            try
            {
                _empleadoService.Delete(id);
                _loggService.Log($"Elimina Empleado", "Empleados", "Delete", _userName);
                return Ok("Baja Correcta");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Eliminar Empleado", "Empleados", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("Update")]
        public IActionResult EmpleadosUpdate([FromForm] EmpleadosUpdate empleado)
        {
            try
            {
                OpEmpleado? opEmpleado = _mapper.Map<OpEmpleado>(empleado);
                _empleadoService.Update(opEmpleado);
                _loggService.Log($"Actualiza Empleado {empleado.Nombre}", "Empleados", "Update", _userName);
                return Ok("Actualización Correcta");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Actualizar Empleado {empleado.Nombre}", "Empleados", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("EmbargoAdd")]
        public IActionResult EmbargoAdd([FromForm] EmpleadoEmbargoAdd embargo)
        {
            try
            {
                embargo.Operador = _userName;
                _empleadoService.EmbargoAdd(embargo);
                _loggService.Log($"Alta Embargo Anticipo {embargo.Anticipo}", "Embargos", "Add", _userName);
                return Ok("Debe confirmar con otro Usuario");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Ingresar Embargo Anticipo {embargo.Anticipo}", "Embargos", "Add", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("EmbargoConfirm")]
        public IActionResult EmbargoConfirm(long embargo)
        {
            try
            {
                _empleadoService.EmbargoConfirm(embargo, _userName);
                _loggService.Log($"Embargo {embargo} confirmado", "Embargos", "Update", _userName);
                return Ok("Debe confirmar con otro Usuario");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Confirmar Embargo Anticipo {embargo}", "Embargos", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpDelete]
        [Route("EmbargoDelete")]
        public IActionResult EmbargoDelete(long id)
        {
            try
            {
                _empleadoService.EmbargoDelete(id);
                _loggService.Log($"Elimina Embargo", "Embargos", "Delete", _userName);
                return Ok("Baja Correcta");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Eliminar Embargo", "Embargos", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("EmbargosGet")]
        public IActionResult EmbargosGet()
        {
            try
            {
                IEnumerable<EmbargosDto>? data = _empleadoService.EmbargosGet();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        #region Auxiliares
        [HttpGet]
        [Route("GetOsocial")]
        public IActionResult GetOsocial()
        {
            IEnumerable<ObraSocial>? data = _obraSocial.Get();
            return Ok(data);
        }

        #endregion

    }
}
