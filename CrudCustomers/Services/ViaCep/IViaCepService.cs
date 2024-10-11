using CrudCustomers.Models.DTOs;

public interface IViaCepService
{
    Task<AddressDto> GetAddressByCep(string cep);
}