using Contracts.DTOs;
using FluentValidation;

namespace Services.Validators
{
    public class GuestAccountDtoValidator : AbstractValidator<GuestAccountDto>
    {
        public GuestAccountDtoValidator() 
        {
            RuleFor(guestAccount => guestAccount.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.");

            RuleFor(guestAccount => guestAccount.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty.");

            RuleFor(guestAccount => guestAccount.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(guestAccount => guestAccount.ContactNumber)
                .NotEmpty().WithMessage("ContactNumber cannot be empty.")
                .Matches("^\\+?[0-9]{1,12}$")
                .WithMessage("ContactNumber must contain only 1-12 digits and optionally start with '+' ");
        }
    }
}


//public int Id { get; set; }
//public string FirstName { get; set; }
//public string LastName { get; set; }
//public string Email { get; set; }
//public string ContactNumber { get; set; }