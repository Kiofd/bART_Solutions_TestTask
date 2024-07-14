using System.ComponentModel.DataAnnotations;
using bART_Solutions_TestTask.DTO.ValidationAttributes;

namespace bART_Solutions_TestTask.DTO;

public class IncidentDto

{
    [Required] 
    public string AccountName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required] 
    [EmailValidation]
    public string Email { get; set; }
    public string Description { get; set; }
}