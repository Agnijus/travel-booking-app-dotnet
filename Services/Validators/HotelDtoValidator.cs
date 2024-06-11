
using travel_booking_app_dotnet.Core.Entities;
using FluentValidation;
using Contracts.DTOs;

namespace Services.Validators
{
    public class HotelDtoValidator : AbstractValidator<HotelDto>
    {
        public HotelDtoValidator() 
        {
            RuleFor(hotel => hotel.Name)
                .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(hotel => hotel.Images)
                .NotNull()
                .Must(images => images.Length == 3).WithMessage("Must contain 3 images.");

            RuleFor(hotel => hotel.Address)
                .NotEmpty().WithMessage("Address cannot be empty.");

            RuleFor(hotel => hotel.City)
                .NotEmpty().WithMessage("City cannot be empty.");

            RuleFor(hotel => hotel.Distance)
                .NotNull().WithMessage("Distance cannot be null.")
                .GreaterThan(0).WithMessage("Distance must be greater than 0.");

            RuleFor(hotel => hotel.StarRating)
                .NotNull().WithMessage("StarRating cannot be null.")
                .InclusiveBetween((byte)1, (byte)5).WithMessage("Star rating must be between 1 and 5.");

            RuleFor(hotel => hotel.GuestRating)
                .NotNull().WithMessage("GuestRating cannot be null.")
                .InclusiveBetween(0f, 5f).WithMessage("Guest rating must be between 0 and 5.");

            RuleFor(hotel => hotel.ReviewCount)
                .NotNull().WithMessage("ReviewCount cannot be null.");
        }
    }
}

//public int Id { get; set; }
//public string Name { get; set; }
//public string[] Images { get; set; }
//public List<Room> Rooms { get; set; } = new List<Room>();
//public string Address { get; set; }
//public string City { get; set; }
//public double Distance { get; set; }
//public byte StarRating { get; set; }
//public float GuestRating { get; set; }
//public ushort ReviewCount { get; set; }
//public bool HasFreeCancellation { get; set; }
//public bool HasPayOnArrival { get; set; }
