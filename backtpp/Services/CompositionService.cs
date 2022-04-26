using backtpp.Interfaces;
using backtpp.Models;
using backtpp.Modelsdtos.Compositions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace backtpp.Services
{
    public class CompositionService : ICompositionService
    {
        private readonly IStoreProcedure _storeProcedure;
        private readonly tppContext _context;
        public CompositionService(IStoreProcedure storeProcedure, tppContext context)
        {
            _storeProcedure = storeProcedure;
            _context = context;
        }

        public bool ComposicionJornalesInsert(List<CompositionJornales> compositionJornales)
        {
            try
            {
                List<SqlParameter> Params = new();
                if (compositionJornales != null)
                {
                    SqlParameter Param = new("@conceptos", AuxDataTable.ToDataTable(compositionJornales))
                    {
                        TypeName = "ConceptosJornalesTable",
                        SqlDbType = SqlDbType.Structured
                    };
                    Params.Add(Param);
                };
                bool res = _storeProcedure.ExecuteNonQuery("ConceptosJornalesAdd", Params);
                return res;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CompositionDto> GetAll()
        {
            try
            {
                DataTable dt = _storeProcedure.SpWhithDataSet("CompositionsGetAll");
                List<CompositionDto> lst = new();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new CompositionDto()  // -- >     Al Automapper
                    {
                        Id = (long)row["Id"],
                        Maniobra = (int)row["Maniobra"],
                        ManiobraStr = row["ManiobraStr"].ToString(),
                        Puesto = (int)row["Puesto"],
                        PuestoStr = row["PuestoStr"].ToString(),
                        Cantidad = (int)row["Cantidad"],
                        Esquema = (int)row["Esquema"],
                        EsquemaStr = row["EsquemaStr"].ToString(),
                    });
                }
                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CompositionJornales> GetCompoJornalesUso(int agrupacion)
        {
            try
            {
                List<SqlParameter> Params = new();
                Params.Add(new SqlParameter("@agrupacion", agrupacion));
                DataTable dt = _storeProcedure.SpWhithDataSet("ConceptosJornalesGet", Params);
                List<CompositionJornales> lst = new();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new CompositionJornales()  // -- >     Al Automapper
                    {
                        Codigo = row["Codigo"].ToString(),
                        Concepto = row["Concepto"].ToString(),
                        Monto = (decimal)row["Monto"],
                        Fijo = (bool)row["Fijo"],
                        Haber = (bool)row["Haber"],
                        Remunerativo = (bool)row["Remunerativo"],
                        Sbasico = (bool)row["Sbasico"],
                        Sbruto = (bool)row["Sbruto"],
                        Sremun = (bool)row["Sremun"],
                        Obligatorio = (bool)row["Obligatorio"]
                    });
                }
                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PuestoDto> GetPuestos()
        {
            try
            {
                DataTable dt = _storeProcedure.SpWhithDataSet("PuestosGetAll");
                List<PuestoDto> lst = new();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new PuestoDto()  // -- >     Al Automapper
                    {
                        Id = (int)row["Id"],
                        Detalle = row["Detalle"].ToString(),
                        Agrupacion = (int)row["Agrupacion"],
                        AgrupacionStr = row["AgrupacionStr"].ToString(),
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
