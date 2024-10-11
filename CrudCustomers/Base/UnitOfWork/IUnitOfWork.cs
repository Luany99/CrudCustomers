using CrudCustomers.Repositories.AddressCtx;
using CrudCustomers.Repositories.CustomerCtx;
using CrudCustomers.Repositories.EmailCtx;
using CrudCustomers.Repositories.PhoneCtx;

namespace CrudCustomers.Base.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        //IAddressRepository Addresses { get; }
        //IPhoneRepository Phones { get; }
        //IEmailRepository Emails { get; }

        Task<int> CommitAsync();
        void Dispose();
    }
}
