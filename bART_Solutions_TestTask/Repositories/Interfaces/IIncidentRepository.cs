using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.Repositories;

public interface IIncidentRepository
{
    Task CreateIncident(Incident incident);
}
    