namespace bART_Solutions_TestTask.Entities;

public record Incident
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int AccountId { get; set; }
}