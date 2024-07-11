using FluentValidation;
using Application.Models.Requests;


namespace travel_app.Validation
{
    public class PostBookingRequestValidator : AbstractValidator<PostBookingRequest>
    {
        public PostBookingRequestValidator() 
        {
            RuleFor(request => request.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.");

            RuleFor(request => request.LastName)
                    .NotEmpty().WithMessage("LastName cannot be empty.");

            RuleFor(request => request.Email)
                    .NotEmpty().WithMessage("Email cannot be empty.")
                    .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(request => request.ContactNumber)
                    .NotEmpty().WithMessage("ContactNumber cannot be empty.")
                    .Matches("^\\+?[0-9]{1,12}$")
                    .WithMessage("ContactNumber must contain only 1-12 digits and optionally start with '+' ");

            RuleFor(request => request.HotelId)
                .NotNull().WithMessage("HotelId cannot be null");

            //RuleFor(request => request.RoomType)
            //    .IsInEnum().WithMessage("RoomType must be a valid type.");

            RuleFor(request => request)
                .Must(request => BeAValidDate(request.CheckInDate)).WithMessage("CheckInDate must not be default DateTime value");

            RuleFor(request => request)
                .Must(request => BeAValidDate(request.CheckOutDate)).WithMessage("CheckOutDate must not be default DateTime value");

            RuleFor(request => request)
                .Must(request => request.CheckInDate < request.CheckOutDate).WithMessage("CheckInDate must be before CheckOutDate.");

            RuleFor(request => request.TotalPrice)
                .NotNull().WithMessage("TotalPrice must not be null")
                .GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
        }
        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.MinValue;
        }

    }
}
