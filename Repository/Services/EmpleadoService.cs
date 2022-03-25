using Microsoft.Data.SqlClient;
using Repository.Interfaces;
using Repository.Models;
using Repository.Modelsdto.Empleados;
using System.Data;


namespace Repository.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IStoreProcedure _storeProcedure;
        private readonly tppContext _context;
        public EmpleadoService(IStoreProcedure storeProcedure, tppContext context)
        {
            _storeProcedure = storeProcedure;
            _context = context;
        }
        public IEnumerable<EmpleadosDto> GetAll(bool? activo)
        {
            try
            {


                List<SqlParameter> Params = new();
                if (activo != null)
                {
                    Params.Add(new SqlParameter("@activo", activo));
                }

                DataTable dt = _storeProcedure.SpWhithDataSet("EmpleadosGetAll", Params);
                List<EmpleadosDto> lst = new();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new EmpleadosDto()  // -- >     Al Automapper
                    {
                        Id = (long)row["Id"],
                        Cuil = (long)row["Cuil"],
                        Nombre = row["Nombre"].ToString(),
                        Puesto = Convert.IsDBNull(row["Puesto"]) ? null : (int)row["Puesto"],
                        PuestoDetalle = row["PuestoDetalle"].ToString()
                    });
                }
                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
