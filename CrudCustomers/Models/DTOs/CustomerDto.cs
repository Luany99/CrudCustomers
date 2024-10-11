namespace CrudCustomers.Models.DTOs
{
    public class CustomerDto
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public List<AddressDto> Addresses { get; set; }
        public List<PhoneDto> Phones { get; set; }
        public List<EmailDto> Emails { get; set; }
    }
}
