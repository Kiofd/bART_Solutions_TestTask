using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.Services;

public interface IIncidentService
{
    Task CreateIncident(string description, string accountName);
}