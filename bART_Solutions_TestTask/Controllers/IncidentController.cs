using AutoMapper;
using bART_Solutions_TestTask.Data;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;
using bART_Solutions_TestTask.Repositories;
using bART_Solutions_TestTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bART_Solutions_TestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IAccountService _accountService;
    private readonly IIncidentService _incidentService;
    private readonly IMapper _mapper;

    public IncidentController(ICustomerService customerService, IMapper mapper, IIncidentService incidentService,
        IAccountService accountService)
    {
        _customerService = customerService;
        _mapper = mapper;
        _incidentService = incidentService;
        _accountService = accountService;
    }

    [HttpPost("CreateIncident")]
    public async Task<ActionResult> CreateIncident(IncidentDto incidentDto)
    {
        var isAccountExist = await _accountService.IsAccountExist(incidentDto.AccountName);

        if (!isAccountExist)
            return NotFound();

        var customer = _mapper.Map<Customer>(incidentDto);

        await _customerService.CreateOrUpdateCustomer(customer, incidentDto.AccountName);

        await _incidentService.CreateIncident(incidentDto.Description, incidentDto.AccountName);

        return Ok();
        // var account = await _repository.GetAccount(incidentDto.AccountName);
        //
        // if (account == null) return NotFound();
        //
        // var customer = await _repository.GetCustomer(incidentDto.Email);
        //
        // if (customer != null)
        //     await _repository.UpdateCustomer(customer, incidentDto, account.Id);
        // else
        //     await _repository.CreateCustomer(incidentDto, account.Id);
        //
        // await _repository.CreateIncident(incidentDto.Description, account.Id);
        //
        // return Ok();
    }

    [HttpPost("Incident")]
    public async Task<ActionResult> Incident(string description, string account)
    {
        _incidentService.CreateIncident(description, account);
        return Ok();
    }
}