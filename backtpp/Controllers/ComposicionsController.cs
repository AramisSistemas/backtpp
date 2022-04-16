using AutoMapper;
using backtpp.Helpers;
using backtpp.Interfaces;
using backtpp.Models;
using backtpp.Modelsdto.Compositions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backtpp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ComposicionsController : Controller
    {
        private readonly IGenericService<OpAgrupacion> _agrupacionService;
        private readonly IGenericService<OpManiobra> _maniobraService;
        private readonly IGenericService<OpPuesto> _puestoService;
        private readonly IGenericService<Esquema> _esquemaService;
        private readonly IGenericService<OpConcepto> _compositionJornalesService;
        private readonly IGenericService<OpComposicion> _genericCompositionService;
        private readonly ICompositionService _compositionService;
        private readonly ILoggService _loggService;
        private readonly IMapper _mapper;
        private readonly SecurityService _securityService;
        private readonly string _userName;
        private readonly int _perfil;
        public ComposicionsController(
            ILoggService loggService,
            SecurityService securityService,
            IMapper mapper,
            IGenericService<OpAgrupacion> agrupacionService,
            IGenericService<OpManiobra> maniobraService,
            IGenericService<OpPuesto> puestoService,
            IGenericService<Esquema> esquemaService,
            ICompositionService compositionService,
            IGenericService<OpComposicion> genericCompositionService,
            IGenericService<OpConcepto> compositionJornalesService
            )
        {
            _esquemaService = esquemaService;
            _puestoService = puestoService;
            _maniobraService = maniobraService;
            _agrupacionService = agrupacionService;
            _compositionService = compositionService;
            _genericCompositionService = genericCompositionService;
            _compositionJornalesService = compositionJornalesService;
            _loggService = loggService;
            _securityService = securityService;
            _userName = _securityService.GetUserAuthenticated();
            _perfil = _securityService.GetPerfilAuthenticated();
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetCompoJornales")]
        public IActionResult GetCompoJornales()
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                IEnumerable<OpConcepto>? data = _compositionJornalesService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetConceptosJornales")]
        public IActionResult GetConceptosJornales(int agrupacion)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                IEnumerable<CompositionJornales>? data = _compositionService.GetCompoJornalesUso(agrupacion);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdateCompoJornales")]
        public IActionResult UpdateCompoJornales([FromForm] CompositionJornales compositionJornales)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpConcepto? OpcompositionJornales = _mapper.Map<OpConcepto>(compositionJornales);
                _compositionJornalesService.Update(OpcompositionJornales);
                _loggService.Log($"Actualiza Concepto Jornales {compositionJornales.Concepto}", "Jornales", "Update", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Concepto Jornales {compositionJornales.Concepto}", "Jornales", "Update", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPut]
        [Route("InsertCompoJornales")]
        public IActionResult InsertCompoJornales([FromBody] List<CompositionJornales> compositionJornales)
        {
            try
            {
                bool data = _compositionService.ComposicionJornalesInsert(compositionJornales);
                _loggService.Log("Composition Jornales Agregados", "Jornales", "Add", _userName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log("Error tratando de Agregar Composition Jornales", "Jornales", "Add", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteCompoJornales")]
        public IActionResult DeleteCompoJornales(long id)
        {
            try
            {
                bool data = _compositionJornalesService.Delete(id);
                _loggService.Log($"Composition Jornal {id} Eliminado ", "Jornales", "Delete", _userName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Eliminar Composition Jornales {id}", "Jornales", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetAgrupaciones")]
        public IActionResult GetAgrupaciones()
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                IEnumerable<OpAgrupacion>? data = _agrupacionService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdateAgrupaciones")]
        public IActionResult UpdateAgrupaciones([FromForm] AgrupacionDto agrupacion)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpAgrupacion? opAgrupacion = _mapper.Map<OpAgrupacion>(agrupacion);
                _agrupacionService.Update(opAgrupacion);
                _loggService.Log($"Actualiza Agrupacion {agrupacion.Detalle}", "Agrupaciones", "Update", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Actualizar Agrupacion {agrupacion.Detalle}", "Agrupaciones", "Update", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("AddAgrupaciones")]
        public IActionResult AddAgrupaciones([FromForm] AgrupacionDto agrupacion)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpAgrupacion? opAgrupacion = _mapper.Map<OpAgrupacion>(agrupacion);
                _loggService.Log($"Ingresa Agrupacion {agrupacion.Detalle}", "Agrupaciones", "Insert", _userName);
                _agrupacionService.Add(opAgrupacion);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Ingresar Agrupacion {agrupacion.Detalle}", "Agrupaciones", "Insert", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteAgrupaciones")]
        public IActionResult DeleteAgrupaciones(int id)
        {
            try
            {
                _agrupacionService.Delete(id);
                _loggService.Log($"Elimina Agrupacion", "Agrupaciones", "Delete", _userName);
                return Ok("Baja Correcta");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Eliminar Agrupacion", "Agrupaciones", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetManiobras")]
        public IActionResult GetManiobras()
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                IEnumerable<OpManiobra>? data = _maniobraService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdateManiobras")]
        public IActionResult UpdateManiobras([FromForm] ManiobraDto maniobra)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpManiobra? opManiobra = _mapper.Map<OpManiobra>(maniobra);
                _maniobraService.Update(opManiobra);
                _loggService.Log($"Actualiza Maniobra {maniobra.Detalle}", "Maniobras", "Update", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Actualizar Maniobra {maniobra.Detalle}", "Maniobras", "Update", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("AddManiobras")]
        public IActionResult AddManiobras([FromForm] ManiobraDto maniobra)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpManiobra? opManiobra = _mapper.Map<OpManiobra>(maniobra);
                _loggService.Log($"Ingresa Maniobra {maniobra.Detalle}", "Maniobras", "Insert", _userName);
                _maniobraService.Add(opManiobra);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Ingresar Maniobra {maniobra.Detalle}", "Maniobras", "Insert", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetPuestos")]
        public IActionResult GetPuestos()
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                IEnumerable<PuestoDto>? data = _compositionService.GetPuestos();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdatePuestos")]
        public IActionResult UpdatePuestos([FromForm] PuestoDto puesto)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpPuesto? opPuesto = _mapper.Map<OpPuesto>(puesto);
                _puestoService.Update(opPuesto);
                _loggService.Log($"Actualiza Puesto {puesto.Detalle}", "Puestos", "Update", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Actualizar Puesto {puesto.Detalle}", "Puestos", "Update", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("AddPuestos")]
        public IActionResult AddPuestos([FromForm] PuestoDto puesto)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpPuesto? opPuesto = _mapper.Map<OpPuesto>(puesto);
                _loggService.Log($"Ingresa Puesto {puesto.Detalle}", "Puesto", "Insert", _userName);
                _puestoService.Add(opPuesto);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Ingresar Puesto {puesto.Detalle}", "Puestos", "Insert", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetEsquemas")]
        public IActionResult GetEsquemas()
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                IEnumerable<Esquema>? data = _esquemaService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdateEsquemas")]
        public IActionResult UpdateEsquemas([FromForm] EsquemaDto esquema)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                Esquema? opEsquema = _mapper.Map<Esquema>(esquema);
                _esquemaService.Update(opEsquema);
                _loggService.Log($"Actualiza Esquema {esquema.Detalle}", "Esquemas", "Update", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Actualizar Esquema {esquema.Detalle}", "Esquema", "Update", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("AddEsquemas")]
        public IActionResult AddEsquemas([FromForm] EsquemaDto esquema)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                Esquema? opEsquema = _mapper.Map<Esquema>(esquema);
                _loggService.Log($"Ingresa Esquema {esquema.Detalle}", "Esquemas", "Insert", _userName);
                _esquemaService.Add(opEsquema);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Ingresar Esquema {esquema.Detalle}", "Esquemas", "Insert", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpGet]
        [Route("GetCompositions")]
        public IActionResult GetCompositions()
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                IEnumerable<CompositionDto>? data = _compositionService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdateCompositions")]
        public IActionResult UpdateCompositions([FromForm] CompositionDto composition)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpComposicion? opComposition = _mapper.Map<OpComposicion>(composition);
                _genericCompositionService.Update(opComposition);
                _loggService.Log($"Actualiza Composition {composition.Id}", "Composition", "Update", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Actualizar Composition {composition.Id}", "Composition", "Update", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }

        [HttpPost]
        [Route("AddCompositions")]
        public IActionResult AddCompositions([FromForm] CompositionDto composition)
        {
            try
            {
                if (_perfil < 3)
                {
                    return BadRequest(new { message = "Este perfil no se encuentra autorizado" });
                }

                OpComposicion? opComposicion = _mapper.Map<OpComposicion>(composition);
                _loggService.Log($"Ingresa Composition {composition.Id}", "Composition", "Insert", _userName);
                _genericCompositionService.Add(opComposicion);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error tratando de Ingresar Composition {composition.Id}", "Composition", "Insert", _userName);
                return BadRequest(new { message = ex.InnerException is not null ? ex.InnerException.Message : ex.Message });
            }
        }
    }
}
