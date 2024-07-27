using System.ComponentModel.DataAnnotations;

namespace bART_Solutions_TestTask.Entities;

public record Account
{
    public int Id { get; set; }
    [Required] 
    public string Name { get; set; }
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public ICollection<Incident> Incidents { get; set; }
}