using FluentValidation;
using Domain.Entities;


namespace travel_booking_app_dotnet.Validation
{
    public class PostBookingRequestValidator : AbstractValidator<PostBookingRequest>
    {
        public PostBookingRequestValidator() 
        {
            // Guest Account

            RuleFor(request => request.GuestAccount.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.");

            RuleFor(request => request.GuestAccount.LastName)
                    .NotEmpty().WithMessage("LastName cannot be empty.");

            RuleFor(request => request.GuestAccount.Email)
                    .NotEmpty().WithMessage("Email cannot be empty.")
                    .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(request => request.GuestAccount.ContactNumber)
                    .NotEmpty().WithMessage("ContactNumber cannot be empty.")
                    .Matches("^\\+?[0-9]{1,12}$")
                    .WithMessage("ContactNumber must contain only 1-12 digits and optionally start with '+' ");

            // Hotel Reservation

            RuleFor(request => request.HotelReservationDetails.HotelId)
                .NotNull().WithMessage("HotelId cannot be null");

            RuleFor(request => request.HotelReservationDetails.RoomType)
                .IsInEnum().WithMessage("RoomType must be a valid type.");

            RuleFor(request => request.HotelReservationDetails)
                .Must(guestAccountHotelBooking => BeAValidDate(guestAccountHotelBooking.CheckInDate)).WithMessage("CheckInDate must not be default DateTime value");

            RuleFor(request => request.HotelReservationDetails)
                .Must(guestAccountHotelBooking => BeAValidDate(guestAccountHotelBooking.CheckOutDate)).WithMessage("CheckOutDate must not be default DateTime value");

            RuleFor(request => request.HotelReservationDetails)
                .Must(guestAccountHotelBooking => guestAccountHotelBooking.CheckInDate < guestAccountHotelBooking.CheckOutDate).WithMessage("CheckInDate must be before CheckOutDate.");

            RuleFor(request => request.HotelReservationDetails.TotalPrice)
                .NotNull().WithMessage("TotalPrice must not be null")
                .GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
        }
        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.MinValue;
        }

    }
}
