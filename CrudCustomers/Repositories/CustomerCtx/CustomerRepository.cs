using CrudCustomers.Base.Repository;
using CrudCustomers.DataContext;
using CrudCustomers.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudCustomers.Repositories.CustomerCtx
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetAllCustomersWithDetailsAsync(int pageNumber, int pageSize)
        {
            return await _dbSet
                .Include(c => c.Addresses)
                .Include(c => c.Phones)
                .Include(c => c.Emails)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize) 
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdWithDetailsAsync(int customerId)
        {
            return await _dbSet
                .Include(c => c.Addresses)
                .Include(c => c.Phones)
                .Include(c => c.Emails)
                .FirstOrDefaultAsync(c => c.Id == customerId);
        }
    }
}
