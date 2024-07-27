using AutoMapper;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;
using bART_Solutions_TestTask.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bART_Solutions_TestTask.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AccountController:ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public AccountController(IAccountService accountService, IMapper mapper, ICustomerService customerService)
    {
        _accountService = accountService;
        _mapper = mapper;
        _customerService = customerService;
    }
    [HttpPost("Create")]
    public async Task<IActionResult> CreateAccount(AccountDto accountDto)
    {
        var isAccountExist = await _accountService.IsAccountExist(accountDto.AccountName);

        if (isAccountExist)
            return BadRequest(new ProblemDetails { Title = "Account already exist" });

        var isCustomerExist = await _customerService.IsCustomerExist(accountDto.Customer.Email);

        if (isCustomerExist)
            return BadRequest(new ProblemDetails { Title = "Customer already exist" });
        
        await _accountService.CreateAccount(accountDto.AccountName, accountDto.Customer);
        return Ok();
    }
    [HttpGet("GetAccount")]
    public async Task<Account> GetAccount(string accountname)
    {
        return await _accountService.GetAccount(accountname);
    }
}
