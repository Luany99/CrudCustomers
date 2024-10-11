using CrudCustomers.Base.Model;

namespace CrudCustomers.Models
{
    public class Email : BaseModel
    {
        public string EmailAddress { get; set; }
        public int CustomerId { get; set; }

        #region Relationships

        public Customer Customer { get; set; }

        #endregion
    }
}
