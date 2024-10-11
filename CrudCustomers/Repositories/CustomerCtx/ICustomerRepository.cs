using CrudCustomers.Base.Repository;
using CrudCustomers.Models;

namespace CrudCustomers.Repositories.CustomerCtx
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<List<Customer>> GetAllCustomersWithDetailsAsync(int pageNumber, int pageSize);
        Task<Customer> GetCustomerByIdWithDetailsAsync(int customerId);
    }
}
