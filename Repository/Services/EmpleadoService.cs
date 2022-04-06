using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Repository.Modelsdto;
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

        public bool Add(EmpleadosAdd empleado)
        {
            try
            {
                List<SqlParameter> Params = new();
                Params.Add(new SqlParameter("@cbu", empleado.Cbu));
                Params.Add(new SqlParameter("@cuil", empleado.Cuil));
                Params.Add(new SqlParameter("@cuilCbu", empleado.CuilCbu));
                Params.Add(new SqlParameter("@nombre", empleado.Nombre));
                Params.Add(new SqlParameter("@sexo", empleado.Sexo));
                _storeProcedure.ExecuteNonQuery("EmpleadosAdd", Params);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(long id)
        {
            OpEmpleado? empleado = _context.OpEmpleados.Find(id);
            if (empleado != null)
            {
                _context.OpEmpleados.Remove(empleado);
                _context.SaveChanges();
            }
        }

        public bool EmbargoAdd(EmpleadoEmbargoAdd empleadoEmbargoAdd)
        {
            try
            {
                List<SqlParameter> Params = new();
                Params.Add(new SqlParameter("@empleado", empleadoEmbargoAdd.Empleado));
                Params.Add(new SqlParameter("@total", empleadoEmbargoAdd.Total));
                Params.Add(new SqlParameter("@monto", empleadoEmbargoAdd.Monto));
                Params.Add(new SqlParameter("@concepto", empleadoEmbargoAdd.Concepto));
                Params.Add(new SqlParameter("@fechaFin", empleadoEmbargoAdd.FechaFin));
                Params.Add(new SqlParameter("@operador", empleadoEmbargoAdd.Operador));
                Params.Add(new SqlParameter("@anticipo", empleadoEmbargoAdd.Anticipo));
                _storeProcedure.ExecuteNonQuery("EmpleadosEmbargoAdd", Params);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EmbargoConfirm(long embargo, string operador)
        {
            var data = _context.OpEmpleadoEmbargoes.SingleOrDefault(x => x.Id == embargo);
            if (data == null)
                return false;
            if (data.Operador == operador) {
                throw new Exception("Debe aprobar otro operador");
            }
            if(data.Activo==true)
            {
                throw new Exception("Ya se encuentra activo");
            }
            data.Activo = true;
            _context.Update(data);
            _context.SaveChanges();
            return true;
        }

        public bool EmbargoDelete(long id)
        {
            OpEmpleadoEmbargo? embargo = _context.OpEmpleadoEmbargoes.Find(id);
            if (embargo != null)
            {
                _context.OpEmpleadoEmbargoes.Remove(embargo);
                _context.SaveChanges();
            }
            return true;
        }

        public IEnumerable<EmbargosDto> EmbargosGet()
        {
            try
            { 
                DataTable dt = _storeProcedure.SpWhithDataSet("EmpleadosEmbargoGet");
                List<EmbargosDto> lst = new();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new EmbargosDto()  // -- >     Al Automapper
                    {
                        Id = (long)row["Id"],
                        Cuil = (long)row["Cuil"],
                        Nombre = row["Nombre"].ToString(),
                        Activo = (bool)row["Activo"],
                        Concepto = row["Concepto"].ToString(),
                        EmpleadoFk = (long)row["EmpleadoFk"],
                        Fin = (DateTime)row["Fin"],
                        Monto = (Decimal)row["Monto"],
                        Total = (Decimal)row["Total"],
                        Operador = row["Operador"].ToString(),
                    });
                }
                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                        Domicilio = row["Domicilio"].ToString(),
                        Telefono = row["Telefono"].ToString(),
                        Ciudad = row["Ciudad"].ToString(),
                        OSocial = Convert.IsDBNull(row["OSocial"]) ? null : (long)row["OSocial"],
                        Nacimiento = (DateTime)row["Nacimiento"],
                        Conyuge = (bool)row["Conyuge"],
                        Hijos = (int)row["Hijos"],
                        Cbu = row["Cbu"].ToString(),
                        CuilCbu = (long)row["CuilCbu"],
                        Activo = (bool)row["Activo"],
                        Ingreso = (DateTime)row["Ingreso"],
                        Sexo = row["Sexo"].ToString(),
                        ObraSocialDetalle = row["ObraSocialDetalle"].ToString(), 
                    });
                }
                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(OpEmpleado empleado)
        { 
            _context.OpEmpleados.Update(empleado); 
            _context.SaveChanges();
            return true;
        }
    }
}
