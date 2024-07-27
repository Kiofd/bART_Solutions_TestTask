using bART_Solutions_TestTask.Data;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace bART_Solutions_TestTask.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IncidentContext _context;
    public AccountRepository(IncidentContext context) => _context = context;

    public async Task<Account?> GetAccount(string accountName)
    {
        return await _context.Accounts
            .Include(c => c.Customers)
            .Include(i => i.Incidents)
            .FirstOrDefaultAsync(n => n.Name == accountName);
    }

    public async Task CreateAccount(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAccount(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Account>> GetAccounts()
    {
        return await _context.Accounts
            .Include(c => c.Customers)
            .Include(i => i.Incidents)
            .ToListAsync();
    }
}