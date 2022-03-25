using Repository.Modelsdtos.Customer;

namespace Repository.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAll(string? filtro, int numpage, int numreg);

        string Delete(long id);
    }
}
