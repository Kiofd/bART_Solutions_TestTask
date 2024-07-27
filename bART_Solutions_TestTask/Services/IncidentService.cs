using bART_Solutions_TestTask.Entities;
using bART_Solutions_TestTask.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bART_Solutions_TestTask.Services;

public class IncidentService : IIncidentService
{
    private readonly IIncidentRepository _incidentRepository;
    private readonly IAccountRepository _accountRepository;

    public IncidentService(IIncidentRepository incidentRepository, IAccountRepository accountRepository)
    {
        _incidentRepository = incidentRepository;
        _accountRepository = accountRepository;
    }
    public async Task CreateIncident(string description, string accountName)
    {
        var account = await _accountRepository.GetAccount(accountName);
        
        var incident = new Incident
        {
            Description = description,
            AccountId = account.Id
        };

        await _incidentRepository.CreateIncident(incident);
    }
}