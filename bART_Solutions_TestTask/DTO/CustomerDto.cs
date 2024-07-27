using System.ComponentModel.DataAnnotations;
using bART_Solutions_TestTask.DTO.ValidationAttributes;

namespace bART_Solutions_TestTask.DTO;

public class CustomerDto
{
    [Required] 
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required] 
    [EmailValidation]
    public string Email { get; set; }
    public string? AccountName { get; set; } // add only to update user or i need a new dto to update customer?
    
}