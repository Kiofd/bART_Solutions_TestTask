using bART_Solutions_TestTask.Data;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;
using bART_Solutions_TestTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bART_Solutions_TestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private readonly IncidentContext _context;
    private readonly IIncidentRepository _repository;

    public IncidentController(IncidentContext context, IIncidentRepository repository)
    {
        _context = context;
        _repository = repository;
    }   

    [HttpPost("CreateIncident")]
    public async Task<ActionResult> CreateIncident(IncidentDto incidentDto)
    {
        var account = await _repository.GetAccount(incidentDto.AccountName);

        if (account == null) return NotFound();

        var customer = await _repository.GetCustomer(incidentDto.Email);

        if (customer != null)
            await _repository.UpdateCustomer(customer, incidentDto, account.Id);
        else
            await _repository.CreateCustomer(incidentDto, account.Id);

        await _repository.CreateIncident(incidentDto.Description, account.Id);

        return Ok();
    }
    
    [HttpPost("CreateAccount")]
    public async Task<ActionResult> CreateAccount(AccountDto accountDto)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(n => n.Name == accountDto.AccountName);

        if (account != null)
        {
            return StatusCode(500);
        }

        await _context.Accounts.AddAsync(new Account
        {
            Name = accountDto.AccountName
        });

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return Ok();
        return BadRequest();
    }

    [HttpGet("GetAllAccounts")]
    public async Task<IEnumerable<Account>> GetAccounts()
    {
       return await _repository.GetAccounts();
    }
}