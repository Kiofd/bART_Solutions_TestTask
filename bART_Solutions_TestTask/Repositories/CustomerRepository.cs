using bART_Solutions_TestTask.Data;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace bART_Solutions_TestTask.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IncidentContext _context;

    
    public CustomerRepository(IncidentContext context) => _context = context;
    
    public async Task<Customer?> GetCustomer(string email)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(e => e.Email == email);
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task CreateCustomer(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCustomer(Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}