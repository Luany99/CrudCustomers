using AutoMapper;
using CrudCustomers.Base.UnitOfWork;
using CrudCustomers.Models;
using CrudCustomers.Models.DTOs;
using FluentValidation;

namespace CrudCustomers.Services.CustomerCtx
{
    public class CustomerService : ICustomerService
    {
        private readonly IValidator<CustomerDto> _validator;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomerService(IValidator<CustomerDto> validator, IUnitOfWork uow, IMapper mapper)
        {
            _validator = validator;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> GetAll(int page, int pageSize) => await _uow.Customers.GetAllCustomersWithDetailsAsync(page, pageSize);

        public async Task<Customer> GetById(int id) => await _uow.Customers.GetCustomerByIdWithDetailsAsync(id);

        public async Task<Customer> Create(CustomerDto customerDto)
        {
            await _validator.ValidateAsync(customerDto);

            Customer customer = _mapper.Map<Customer>(customerDto);

            await _uow.Customers.Add(customer);
            await _uow.CommitAsync();

            return customer;
        }

        public async Task<Customer> Update(int id, CustomerDto customerDto)
        {
            Customer existingCustomer = await _uow.Customers.GetCustomerByIdWithDetailsAsync(id);
            if (existingCustomer is null) throw new ValidationException("Cliente não localizado na base de dados");

            _mapper.Map(customerDto, existingCustomer);
            await _uow.Customers.Update(existingCustomer);
            await _uow.CommitAsync();
            return existingCustomer;
        }

        public async Task<bool> Delete(int id)
        {
            Customer customer = await _uow.Customers.GetCustomerByIdWithDetailsAsync(id);
            if (customer is null) throw new ValidationException("Cliente não localizado na base de dados");

            await _uow.Customers.Delete(customer);
            await _uow.CommitAsync();
            return true;
        }
    }
}
