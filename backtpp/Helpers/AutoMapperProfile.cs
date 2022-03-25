using AutoMapper;
using Repository.Models;
using Repository.Modelsdto.Empleados;
using Repository.Modelsdto.Operations;
using Repository.Modelsdto.Users;
using Repository.Modelsdtos.Commons;
using Repository.Modelsdtos.Users;

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
        }
    }
}