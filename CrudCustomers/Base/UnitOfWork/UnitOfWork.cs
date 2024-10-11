using CrudCustomers.DataContext;
using CrudCustomers.Repositories.AddressCtx;
using CrudCustomers.Repositories.CustomerCtx;
using CrudCustomers.Repositories.EmailCtx;
using CrudCustomers.Repositories.PhoneCtx;

namespace CrudCustomers.Base.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICustomerRepository Customers { get; }
        public IAddressRepository Addresses { get; }
        public IPhoneRepository Phones { get; }
        public IEmailRepository Emails { get; }

        public UnitOfWork(ApplicationDbContext context, ICustomerRepository customerRepository, IAddressRepository addressRepository, IPhoneRepository phoneRepository, IEmailRepository emailRepository)
        {
            _context = context;
            Customers = customerRepository;
            Addresses = addressRepository;
            Phones = phoneRepository;
            Emails = emailRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
