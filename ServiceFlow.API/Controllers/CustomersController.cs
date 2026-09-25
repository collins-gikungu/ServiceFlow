using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceFlow.API.Data;
using ServiceFlow.API.Models;

namespace ServiceFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ServiceFlowDbContext _context;

    public CustomersController(ServiceFlowDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }
    [HttpPost]
public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
{
    _context.Customers.Add(customer);
    await _context.SaveChangesAsync();

    return CreatedAtAction(
        nameof(GetCustomers),
        new { id = customer.Id },
        customer);
}
[HttpGet("{id}")]
public async Task<ActionResult<Customer>> GetCustomer(int id)
{
    var customer = await _context.Customers.FindAsync(id);

    if (customer == null)
    {
        return NotFound();
    }

    return customer;
}
[HttpPut("{id}")]
public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
{
    var existingCustomer = await _context.Customers.FindAsync(id);

    if (existingCustomer == null)
    {
        return NotFound();
    }

    existingCustomer.Name = customer.Name;
    existingCustomer.Email = customer.Email;
    existingCustomer.Phone = customer.Phone;

    await _context.SaveChangesAsync();

    return NoContent();
}
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteCustomer(int id)
{
    var customer = await _context.Customers.FindAsync(id);

    if (customer == null)
    {
        return NotFound();
    }

    _context.Customers.Remove(customer);
    await _context.SaveChangesAsync();

    return NoContent();
}
}