using AutoMapper;
using backtpp.Helpers;
using backtpp.Interfaces;
using backtpp.Models;
using backtpp.Modelsdto.Customers;
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
        private readonly IGenericService<ClienteResponsabilidad> _responsabilidadGenService;
        private readonly IGenericService<ClienteGenero> _generoGenService;
        private readonly IGenericService<ProveedorImputacion> _imputacionGenService;
        private readonly ILoggService _loggService;
        private readonly IMapper _mapper;
        private readonly SecurityService _securityService;
        private readonly string _userName;
        private readonly int _perfil;
        public CustomersController(
            IGenericService<Cliente> clienteGenService,
            IGenericService<OpDestino> destinoGenService,
            IGenericService<ClienteResponsabilidad> responsabilidadGenService,
            IGenericService<ClienteGenero> generoGenService,
            IGenericService<ProveedorImputacion> imputacionGenService,
            ILoggService loggService,
            SecurityService securityService,
            IMapper mapper
            )
        {
            _clienteGenService = clienteGenService;
            _destinoGenService = destinoGenService;
            _responsabilidadGenService = responsabilidadGenService;
            _generoGenService = generoGenService;
            _imputacionGenService = imputacionGenService;
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

        [HttpPut]
        [Route("Add")]
        public IActionResult Add([FromForm] CustomerAdd customer)
        {
            Cliente? cliente = _mapper.Map<Cliente>(customer);
            try
            {
                _clienteGenService.Add(cliente);
                _loggService.Log($"Alta de {customer.Nombre}", "Clientes", "Insert", _userName);
                return Ok("Alta Correcta");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Ingresar a {customer.Nombre}", "Clientes", "Insert", _userName);
                // return error message if there was an exception
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

        [HttpGet]
        [Route("GetResponsabilidades")]
        public IActionResult GetResponsabilidades()
        {
            try
            {
                IEnumerable<ClienteResponsabilidad>? data = _responsabilidadGenService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetGeneros")]
        public IActionResult GetGeneros()
        {
            try
            {
                IEnumerable<ClienteGenero>? data = _generoGenService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetImputaciones")]
        public IActionResult GetImputaciones()
        {
            try
            {
                IEnumerable<ProveedorImputacion>? data = _imputacionGenService.Get();
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
