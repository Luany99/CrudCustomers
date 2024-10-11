using CrudCustomers.Models.DTOs;
using CrudCustomers.Models;

namespace CrudCustomers.Services.CustomerCtx
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll(int page, int pageSize);
        Task<Customer> GetById(int id);
        Task<Customer> Create(CustomerDto customerDto);
        Task<Customer> Update(int id, CustomerDto customerDto);
        Task<bool> Delete(int id);
    }
}
