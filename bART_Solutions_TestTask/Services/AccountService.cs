using bART_Solutions_TestTask.Entities;
using bART_Solutions_TestTask.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bART_Solutions_TestTask.Services;

public class AccountService:IAccountService
{
    private readonly IAccountRepository _accountRepository;
   // private readonly ICustomerService _customerService;

    public AccountService(IAccountRepository accountRepository, ICustomerService customerService)
    {
        _accountRepository = accountRepository;
       //_customerService = customerService;
    }

    public async Task CreateAccount(string accountName, Customer customer)
    {
        var account = new Account
        {
            Name = accountName,
            Customers = new List<Customer>{customer}
        };
        
        await _accountRepository.CreateAccount(account);
    }

    public async Task<Account> GetAccount(string accountName)
    {
        return await _accountRepository.GetAccount(accountName);
    }

    public async Task<bool> IsAccountExist(string accountName)
    {
        var isExist = await _accountRepository.GetAccount(accountName);

        if (isExist != null)
            return true;

        return false;
    }
}