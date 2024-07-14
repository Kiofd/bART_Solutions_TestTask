using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace bART_Solutions_TestTask.DTO.ValidationAttributes;

public class EmailValidationAttribute : ValidationAttribute
{
    private const string _regex = 
        "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string email)
        {
            Regex regex = new Regex(_regex);

            Match match = regex.Match(email);
            if (match.Success)
                return ValidationResult.Success;
        }

        return new ValidationResult("Invalid email");
    }
}