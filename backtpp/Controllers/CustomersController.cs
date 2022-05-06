using AutoMapper;
using backtpp.Helpers;
using backtpp.Interfaces;
using backtpp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backtpp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IGenericService<Cliente> _clienteGenService;
        private readonly IGenericService<OpDestino> _destinoGenService;
        private readonly ILoggService _loggService;
        private readonly IMapper _mapper;
        private readonly SecurityService _securityService;
        private readonly string _userName;
        private readonly int _perfil;
        public CustomersController(
            IGenericService<Cliente> clienteGenService,
            IGenericService<OpDestino> destinoGenService,
            ILoggService loggService,
            SecurityService securityService,
            IMapper mapper
            )
        {
            _clienteGenService = clienteGenService;
            _destinoGenService = destinoGenService;
            _loggService = loggService;
            _securityService = securityService;
            _userName = _securityService.GetUserAuthenticated();
            _perfil = _securityService.GetPerfilAuthenticated();
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetClientes")]
        public IActionResult GetClientes()
        {
            try
            {
                IEnumerable<Cliente>? data = _clienteGenService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        #region
        [HttpGet]
        [Route("GetDestinos")]
        public IActionResult GetDestinos()
        {
            try
            {
                IEnumerable<OpDestino>? data = _destinoGenService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }
        #endregion
    }
}
