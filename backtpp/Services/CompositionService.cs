using backtpp.Interfaces;
using backtpp.Models;
using backtpp.Modelsdto.Compositions;
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
