using Contracts.DTOs;
using FluentValidation;

namespace Services.Validators
{
    public class GuestAccountHotelBookingDtoValidator : AbstractValidator<GuestAccountHotelBookingDto>
    {
        public GuestAccountHotelBookingDtoValidator() 
        {
            // Guest Account DTO

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.");

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking.LastName)
                    .NotEmpty().WithMessage("LastName cannot be empty.");

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking.Email)
                    .NotEmpty().WithMessage("Email cannot be empty.")
                    .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking.ContactNumber)
                    .NotEmpty().WithMessage("ContactNumber cannot be empty.")
                    .Matches("^\\+?[0-9]{1,12}$")
                    .WithMessage("ContactNumber must contain only 1-12 digits and optionally start with '+' ");

            // Hotel Reservation DTO

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking.HotelId)
                .NotNull().WithMessage("HotelId cannot be null");

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking.RoomType)
                .IsInEnum().WithMessage("RoomType must be a valid type.");

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking)
                .Must(guestAccountHotelBooking => BeAValidDate(guestAccountHotelBooking.CheckInDate)).WithMessage("CheckInDate must not be default DateTime value");

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking)
                .Must(guestAccountHotelBooking => BeAValidDate(guestAccountHotelBooking.CheckOutDate)).WithMessage("CheckOutDate must not be default DateTime value");

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking)
                .Must(guestAccountHotelBooking => guestAccountHotelBooking.CheckInDate < guestAccountHotelBooking.CheckOutDate).WithMessage("CheckInDate must be before CheckOutDate.");

            RuleFor(guestAccountHotelBooking => guestAccountHotelBooking.TotalPrice)
                .NotNull().WithMessage("TotalPrice must not be null")
                .GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
        }
        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.MinValue;
        }

    }
}
