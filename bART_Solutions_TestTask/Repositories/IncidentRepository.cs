using bART_Solutions_TestTask.Data;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace bART_Solutions_TestTask.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly IncidentContext _context;

    public IncidentRepository(IncidentContext context) => _context = context;

    public async Task CreateIncident(Incident incident)
    {
        await _context.Incidents.AddAsync(incident);
        await _context.SaveChangesAsync();
    }
}