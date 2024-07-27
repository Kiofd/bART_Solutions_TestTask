using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.Services;

public interface ICustomerService
{
    Task CreateCustomer(Customer customer);
    Task UpdateCustomer(Customer customer, string accountName);
    Task<bool> IsCustomerExist(string email);
    Task CreateOrUpdateCustomer(Customer customer, string accountName);
}