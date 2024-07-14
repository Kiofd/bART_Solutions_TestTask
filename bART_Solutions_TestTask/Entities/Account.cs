namespace bART_Solutions_TestTask.Entities;

public record Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<Incident> Incidents { get; set; }
}