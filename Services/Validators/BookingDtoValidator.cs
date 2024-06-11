using Contracts.DTOs;
using Domain.Entities;
using FluentValidation;


namespace Services.Validators
{
    public class BookingDtoValidator : AbstractValidator<BookingDto>
    {
        public BookingDtoValidator() 
        {
            RuleFor(booking => booking.AccountId)
                .NotNull().WithMessage("AccountId cannot be null.");

            RuleFor(booking => booking.ReservationId)
                .NotNull().WithMessage("ReservationId cannot be null.");

            RuleFor(booking => booking.TotalPrice)
                .NotNull().WithMessage("TotalPrice cannot be null.")
                .GreaterThan(0).WithMessage("TotalPrice must be greater than 0.");

            RuleFor(booking => booking.Status)
                .IsInEnum().WithMessage("Status must be a valid type.");
        }
    }
}

//public int Id { get; set; }
//public int AccountId { get; set; }
//public int ReservationId { get; set; }
//public double TotalPrice { get; set; }
//public TransactionStatus Status { get; set; }
