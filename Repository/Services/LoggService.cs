using AutoMapper;
using Repository.Interfaces;
using Repository.Models;
using Repository.Modelsdtos.Commons;

namespace Repository.Services
{
    public class LoggService : ILoggService
    {
        private readonly tppContext _context;
        private readonly IMapper _mapper;
        public LoggService(IMapper mapper)
        {
            tppContext context = new();
            _context = context;
            _mapper = mapper;
        }
        public void Log(string detalle, string modulo, string tipo, string operador)
        {
            LoggModel loggModel = new()
            {
                Detalle = detalle,
                Modulo = modulo,
                Tipo = tipo,
                Fecha = System.DateTime.Now,
                Operador = operador
            };
            UserLog? logg = _mapper.Map<UserLog>(loggModel);
            _context.UserLogs.Add(logg);
            _context.SaveChanges();
        }
    }
}
