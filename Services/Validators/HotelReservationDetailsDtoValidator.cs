using Contracts.DTOs;
using FluentValidation;

namespace Services.Validators
{
    public class HotelReservationDetailsDtoValidator : AbstractValidator<HotelReservationDetailsDto>
    {
        public HotelReservationDetailsDtoValidator() 
        {
            RuleFor(hotelReservation => hotelReservation.HotelId)
                .NotNull().WithMessage("HotelId cannot be null");

            RuleFor(hotelReservation => hotelReservation.RoomType)
                .IsInEnum().WithMessage("RoomType must be a valid type.");

            RuleFor(hotelReservation => hotelReservation)
                .Must(hotelReservation => BeAValidDate(hotelReservation.CheckInDate)).WithMessage("CheckInDate must not be default DateTime value");

            RuleFor(hotelReservation => hotelReservation)
                .Must(hotelReservation => BeAValidDate(hotelReservation.CheckOutDate)).WithMessage("CheckOutDate must not be default DateTime value");

            RuleFor(hotelReservation => hotelReservation)
                .Must(hotelReservation => hotelReservation.CheckInDate < hotelReservation.CheckOutDate).WithMessage("CheckInDate must be before CheckOutDate.");

            RuleFor(hotelReservation => hotelReservation.TotalPrice)
                .NotNull().WithMessage("TotalPrice must not be null")
                .GreaterThan(0).WithMessage("TotalPrice must be greater than 0");

        }

        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.MinValue;
        }
    }


}


//public int Id { get; set; }
//public int HotelId { get; set; }
//public RoomType RoomType { get; set; }
//public DateTime CheckInDate { get; set; }
//public DateTime CheckOutDate { get; set; }
//public double TotalPrice { get; set; }
