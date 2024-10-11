using CrudCustomers.Base.Repository;
using CrudCustomers.DataContext;
using CrudCustomers.Models;

namespace CrudCustomers.Repositories.PhoneCtx
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
