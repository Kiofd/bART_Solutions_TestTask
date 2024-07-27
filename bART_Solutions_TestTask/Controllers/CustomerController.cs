using bART_Solutions_TestTask.DTO;
using AutoMapper;
using bART_Solutions_TestTask.Entities;
using bART_Solutions_TestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace bART_Solutions_TestTask.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomerController:ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        await _customerService.CreateCustomer(customer);
        return Ok();
    }
    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto)
    {
        var updateCustomer = _mapper.Map<Customer>(customerDto);
        await _customerService.UpdateCustomer(updateCustomer, customerDto.AccountName);
        return Ok();
    }
}