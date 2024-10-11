using CrudCustomers.Base.Model;

namespace CrudCustomers.Models
{
    public class Phone : BaseModel
    {
        public string Number { get; set; }
        public int CustomerId { get; set; }

        #region Relationships

        public Customer Customer { get; set; }

        #endregion
    }
}
