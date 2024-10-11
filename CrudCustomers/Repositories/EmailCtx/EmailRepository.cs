using CrudCustomers.Base.Repository;
using CrudCustomers.DataContext;
using CrudCustomers.Models;

namespace CrudCustomers.Repositories.EmailCtx
{
    public class EmailRepository : BaseRepository<Email>, IEmailRepository
    {
        public EmailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
