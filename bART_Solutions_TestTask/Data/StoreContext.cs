using bART_Solutions_TestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace bART_Solutions_TestTask.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Incident> Incidents { get; set; }
}