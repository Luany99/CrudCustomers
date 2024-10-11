using CrudCustomers.Base.Model;

namespace CrudCustomers.Models
{
    public class Address : BaseModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Number { get; set; }
        public int CustomerId { get; set; }

        #region Relationships

        public Customer Customer { get; set; }

        #endregion
    }
}
