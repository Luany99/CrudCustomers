using CrudCustomers.Base.Model;

namespace CrudCustomers.Models
{
    public class Customer : BaseModel
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
    }
}
