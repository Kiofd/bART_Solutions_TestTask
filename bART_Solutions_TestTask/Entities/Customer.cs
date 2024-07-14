﻿namespace bART_Solutions_TestTask.Entities;

public record Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int AccountId { get; set; }
}