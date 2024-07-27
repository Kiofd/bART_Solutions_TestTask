using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.Repositories;

public interface IAccountRepository
{
    Task<Account?> GetAccount(string accountName);
    Task<IEnumerable<Account>> GetAccounts();
    Task CreateAccount(Account customer);
    Task DeleteAccount(int id);
}