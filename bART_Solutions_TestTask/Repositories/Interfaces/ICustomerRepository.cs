using bART_Solutions_TestTask.Data;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.Repositories;

public interface ICustomerRepository
{
    Task<Customer> GetCustomer(string email);
    Task<IEnumerable<Customer>> GetCustomers();
    Task CreateCustomer(Customer customer);
    Task UpdateCustomer(Customer customer);
    Task DeleteCustomer(int id);
}