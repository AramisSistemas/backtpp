using backtpp.Interfaces;
using backtpp.Models;
using backtpp.Modelsdtos.Customer;
using Microsoft.Data.SqlClient;
using System.Data;

namespace backtpp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IStoreProcedure _storeProcedure;
        private readonly tppContext _context;
        public CustomerService(IStoreProcedure storeProcedure, tppContext context)
        {
            _storeProcedure = storeProcedure;
            _context = context;
        }

        public string Delete(long id)
        {
            try
            {

                Cliente? cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
                if (cliente == null)
                {
                    throw new Exception("El cliente ya se ha eliminado");
                }

                if (cliente.Saldo != 0)
                {
                    throw new Exception("El cliente " + cliente.Nombre + " posee saldo pendiente");
                }

                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return cliente.Nombre;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CustomerModel> GetAll(string? filtro, int numpage, int numreg)
        {
            try
            {


                List<SqlParameter> Params = new();
                if (filtro != null)
                {
                    Params.Add(new SqlParameter("@filtro", filtro));
                }

                Params.Add(new SqlParameter("@numpage", numpage));
                Params.Add(new SqlParameter("@numreg", numreg));
                DataTable dt = _storeProcedure.SpWhithDataSet("CustomerGetAll", Params);
                List<CustomerModel> lst = new();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new CustomerModel()  // -- >     Al Automapper
                    {
                        Id = (long)row["Id"],
                        Cuit = (long)row["Cuit"],
                        Nombre = row["Nombre"].ToString(),
                        Responsabilidad = row["Responsabilidad"].ToString(),
                        //Paginacion
                        Pagina = numpage,
                        TotalPages = (int)row["Paginas"],
                        TotalRegistros = (int)row["Registros"],
                        Registros = numreg
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
