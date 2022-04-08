using AutoMapper;
using backtpp.Models;
using backtpp.Modelsdto.Compositions;
using backtpp.Modelsdto.Empleados;
using backtpp.Modelsdto.Operations;
using backtpp.Modelsdto.Users;
using backtpp.Modelsdtos.Commons;
using backtpp.Modelsdtos.Users;

namespace backtpp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<AddUser, User>().ReverseMap();
            CreateMap<EditUser, User>().ReverseMap();
            CreateMap<UserPerfil, PerfilModel>().ReverseMap();
            CreateMap<ManiobraModel, OperacionManiobra>().ReverseMap();
            CreateMap<ManiobraModel, OpManiobra>().ReverseMap();
            CreateMap<TurnoModel, Turno>().ReverseMap();
            CreateMap<LoggModel, UserLog>().ReverseMap();
            CreateMap<OpEmpleado, EmpleadosDto>().ReverseMap();
            CreateMap<OpEmpleado, EmpleadosUpdate>().ReverseMap();
            CreateMap<OpAgrupacion, AgrupacionDto>().ReverseMap();
            CreateMap<OpManiobra, ManiobraDto>().ReverseMap();
            CreateMap<OpPuesto, PuestoDto>().ReverseMap();
            CreateMap<Esquema, EsquemaDto>().ReverseMap();
            CreateMap<OpComposicion, CompositionDto>().ReverseMap();
        }
    }
}