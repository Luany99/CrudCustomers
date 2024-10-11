using CrudCustomers.Base.Repository;
using CrudCustomers.DataContext;
using CrudCustomers.Models;

namespace CrudCustomers.Repositories.AddressCtx
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
