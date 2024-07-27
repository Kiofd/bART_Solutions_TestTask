using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.Services;

public interface IAccountService
{
    Task CreateAccount(string accountName, Customer customer);
    Task<Account> GetAccount(string accountName);
    Task<bool> IsAccountExist (string accountName);
}