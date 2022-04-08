using backtpp.Modelsdtos.Customer;

namespace backtpp.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAll(string? filtro, int numpage, int numreg);

        string Delete(long id);
    }
}
