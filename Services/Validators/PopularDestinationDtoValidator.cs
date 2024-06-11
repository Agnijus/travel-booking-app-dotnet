using Contracts.DTOs;
using FluentValidation;


namespace Services.Validators
{
    public class PopularDestinationDtoValidator : AbstractValidator<PopularDestinationDto>
    {
        public PopularDestinationDtoValidator() 
        {
            RuleFor(popularDestination => popularDestination.Name)
               .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(popularDestination => popularDestination.Location)
               .NotEmpty().WithMessage("Location cannot be empty");
        }
    }
}

//public string Name { get; set; }
//public string Location { get; set; }
