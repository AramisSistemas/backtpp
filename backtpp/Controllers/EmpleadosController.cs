using backtpp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Modelsdto.Empleados;

namespace backtpp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly ILoggService _loggService;
        private readonly SecurityService _securityService;
        private readonly string _userName;
        public EmpleadosController(IEmpleadoService empleadoService, ILoggService loggService, SecurityService securityService)
        {
            _securityService = securityService;
            _empleadoService = empleadoService;
            _loggService = loggService;
            _userName = _securityService.GetUserAuthenticated();
        }

        [HttpGet]
        public IActionResult GetAll(bool? activo)
        {
            IEnumerable<EmpleadosDto>? data = _empleadoService.GetAll(activo);
            return Ok(data);
        }

    }
}
