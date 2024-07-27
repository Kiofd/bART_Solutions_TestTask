using bART_Solutions_TestTask.Entities;
using bART_Solutions_TestTask.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bART_Solutions_TestTask.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IAccountRepository _accountRepository;

    public CustomerService(ICustomerRepository customerRepository, IAccountRepository accountRepository)
    {
        _customerRepository = customerRepository;
        _accountRepository = accountRepository;
    }

    public async Task CreateCustomer(Customer customer)
    {
        await _customerRepository.CreateCustomer(customer);
    }

    public async Task UpdateCustomer(Customer customer, string accountName)
    {
        var account = await _accountRepository.GetAccount(accountName);

        var customerToUpdate = await _customerRepository.GetCustomer(customer.Email);

        customerToUpdate.FirstName = customer.FirstName;
        customerToUpdate.LastName = customer.LastName;
        customerToUpdate.AccountId = account.Id;

        await _customerRepository.UpdateCustomer(customerToUpdate);
    }

    public async Task<bool> IsCustomerExist(string email)
    {
        var isExist = await _customerRepository.GetCustomer(email);

        if (isExist != null)
            return true;

        return false;
    }

    public async Task CreateOrUpdateCustomer(Customer customer, string accountName)
    {
        var isCustomerExist = await IsCustomerExist(customer.Email);

        if (isCustomerExist)
            await UpdateCustomer(customer, accountName);
        else
            await CreateCustomer(customer);
    }
}