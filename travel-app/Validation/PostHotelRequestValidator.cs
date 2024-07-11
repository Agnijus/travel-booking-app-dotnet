using FluentValidation;
using Application.Models.Requests;

namespace travel_app.Validation
{
    public class PostHotelRequestValidator : AbstractValidator<PostHotelRequest>
    {
        public PostHotelRequestValidator()
        {

            RuleFor(request => request.Title)
                    .NotEmpty().WithMessage("Name cannot be empty");

            //RuleFor(request => request.Images)
            //        .NotNull()
            //        .Must(images => images?.Length == 3).WithMessage("Must contain 3 images.");

            RuleFor(request => request.Address)
                    .NotEmpty().WithMessage("Address cannot be empty.");

            RuleFor(request => request.City)
                    .NotEmpty().WithMessage("City cannot be empty.");

            RuleFor(request => request.Distance)
                    .NotNull().WithMessage("Distance cannot be null.")
                    .GreaterThan(0).WithMessage("Distance must be greater than 0.");

            RuleFor(request => request.StarRating)
                    .NotNull().WithMessage("StarRating cannot be null.")
                    .InclusiveBetween((byte)1, (byte)5).WithMessage("Star rating must be between 1 and 5.");

            RuleFor(request => request.GuestRating)
                    .NotNull().WithMessage("GuestRating cannot be null.")
                    .InclusiveBetween(0f, 5f).WithMessage("Guest rating must be between 0 and 5.");

            RuleFor(request => request.ReviewCount)
                    .NotNull().WithMessage("ReviewCount cannot be null.");
        }
    }
}
