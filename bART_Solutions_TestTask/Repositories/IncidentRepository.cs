using bART_Solutions_TestTask.Data;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace bART_Solutions_TestTask.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly IncidentContext _context;

    public IncidentRepository(IncidentContext context) => _context = context;

    public async Task<Account> GetAccount(string accountName)
    {
        var account = await _context.Accounts
            .FirstOrDefaultAsync(n => n.Name == accountName);

        return account;
    }
    public async Task<IEnumerable<Account>> GetAccounts()
    {
        var account = await _context.Accounts
            .Include(c => c.Customers)
            .Include(i => i.Incidents)
            .ToListAsync();

        if (account == null)
            throw new Exception("There are no accounts");

        return account;
    }
    
    public async Task<Customer> GetCustomer(string email)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(e => e.Email == email);

        return customer;
    }

    public async Task<Customer> CreateCustomer(IncidentDto incidentDto, int accountId)
    {
        var customer = new Customer
        {
            FirstName = incidentDto.FirstName,
            LastName = incidentDto.LastName,
            Email = incidentDto.Email,
            AccountId = accountId
        };

        await _context.Customers.AddAsync(customer);

        await _context.SaveChangesAsync();
        
        return customer;
    }

    public async Task UpdateCustomer(Customer customer, IncidentDto incidentDto, int accountId)
    {
        customer.FirstName = incidentDto.FirstName;
        customer.LastName = incidentDto.LastName;
        customer.Email = incidentDto.Email;
        customer.AccountId = accountId;

        _context.Customers.Update(customer);
        
        await _context.SaveChangesAsync();
    }

    public async Task<Incident> CreateIncident(string description, int accountId)
    {
        var incident = new Incident
        {
            Description = description,
            AccountId = accountId
        };

        await _context.Incidents.AddAsync(incident);

        await _context.SaveChangesAsync();

        return incident;    
    }
}