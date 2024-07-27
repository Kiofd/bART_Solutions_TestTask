﻿using System.ComponentModel.DataAnnotations;
using bART_Solutions_TestTask.DTO.ValidationAttributes;

namespace bART_Solutions_TestTask.Entities;

public record Customer
{
    public int Id { get; set; }
    [Required] 
    public string FirstName { get; set; }
    [Required] 
    public string LastName { get; set; }
    [Required] 
    [EmailValidation]
    public string Email { get; set; }
    public int AccountId { get; set; }
}