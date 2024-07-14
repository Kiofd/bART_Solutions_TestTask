using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.Repositories;

public interface IIncidentRepository
{
    Task<Account> GetAccount(string accountName);
    Task<IEnumerable<Account>> GetAccounts();
    Task<Customer> GetCustomer(string email);
    Task<Customer> CreateCustomer(IncidentDto incidentDto, int accountId);
    Task UpdateCustomer(Customer customer, IncidentDto incidentDto, int accountId);
    Task<Incident> CreateIncident(string description, int accountId);
    
}
    