using AutoMapper;
using CrudCustomers.Base.UnitOfWork;
using CrudCustomers.Models;
using CrudCustomers.Models.DTOs;
using CrudCustomers.Services.CustomerCtx;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace CrudCustomers.Tests;
public class CustomerServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly Mock<IValidator<CustomerDto>> _mockValidator;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CustomerService _customerService;

    public CustomerServiceTests()
    {
        _mockUow = new Mock<IUnitOfWork>();
        _mockValidator = new Mock<IValidator<CustomerDto>>();
        _mockMapper = new Mock<IMapper>();
        _customerService = new CustomerService(_mockValidator.Object, _mockUow.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Create()
    {
        // Arrange
        var customerDto = new CustomerDto
        {
            CNPJ = "12.345.678/0001-90",
            Name = "Test Customer",
            Addresses = new List<AddressDto>
        {
            new AddressDto
            {
                Street = "Test Street",
                City = "Test City",
                State = "TS",
                Neighborhood = "Test Neighborhood",
                ZipCode = "12345-678",
                Number = "123"
            }
        },
            Phones = new List<PhoneDto>
        {
            new PhoneDto { Number = "1234-5678" }
        },
            Emails = new List<EmailDto>
        {
            new EmailDto { EmailAddress = "test@customer.com" }
        }
        };

        var customer = new Customer
        {
            Id = 1,
            CNPJ = "12.345.678/0001-90",
            Name = "Test Customer",
            Addresses = new List<Address>
        {
            new Address
            {
                Street = "Test Street",
                City = "Test City",
                State = "TS",
                Neighborhood = "Test Neighborhood",
                ZipCode = "12345-678",
                Number = "123"
            }
        },
            Phones = new List<Phone>
        {
            new Phone { Number = "1234-5678" }
        },
            Emails = new List<Email>
        {
            new Email { EmailAddress = "test@customer.com" }
        }
        };

        _mockValidator.Setup(v => v.ValidateAsync(customerDto, default))
                      .ReturnsAsync(new ValidationResult());

        _mockMapper.Setup(m => m.Map<Customer>(customerDto)).Returns(customer);

        _mockUow.Setup(u => u.Customers.Add(customer)).Verifiable();
        _mockUow.Setup(u => u.CommitAsync()).Verifiable();

        // Act
        var result = await _customerService.Create(customerDto);

        // Assert
        Assert.Equal(customer, result);
        _mockUow.Verify(u => u.CommitAsync(), Times.Once);
    }
}
