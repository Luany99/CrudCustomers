using CrudCustomers.Models.DTOs;
using CrudCustomers.Services.CustomerCtx;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IViaCepService _viaCepService;


    public CustomerController(ICustomerService customerService, IViaCepService viaCepService)
    {
        _customerService = customerService;
        _viaCepService = viaCepService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var customers = await _customerService.GetAll(page, pageSize);
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerService.GetById(id);
        if (customer is null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customer)
    {
        try
        {
            var newCustomer = await _customerService.Create(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
        }
        catch (Exception ex)
        {

            return BadRequest(ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customer)
    {
        var updatedCustomer = await _customerService.Update(id, customer);
        if (updatedCustomer is null) return NotFound();
        return Ok(updatedCustomer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var deleted = await _customerService.Delete(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpGet("address/{cep}")]
    public async Task<IActionResult> GetAddressByCep(string cep)
    {
        var address = await _viaCepService.GetAddressByCep(cep);
        if (address is null) return NotFound("Endereço não encontrado para o CEP fornecido.");
        return Ok(address);
    }
}

