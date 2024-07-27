using System.ComponentModel.DataAnnotations;
using bART_Solutions_TestTask.DTO.ValidationAttributes;
using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.DTO;

public class AccountDto
{
    [Required]
    public string AccountName { get; set; }
    [Required]
    public Customer Customer { get; set; }
}