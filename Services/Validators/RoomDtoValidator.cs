using Contracts.DTOs;
using Domain.Enums;
using FluentValidation;


namespace Services.Validators
{
    public class RoomDtoValidator : AbstractValidator<RoomDto>
    {
        public RoomDtoValidator() 
        {
            RuleFor(room => room.RoomType)
                .IsInEnum().WithMessage("RoomType must be a valid type.");

            RuleFor(room => room.PricePerNight)
                .GreaterThan((ushort)0).WithMessage("PricePerNight must be greater than 0.");

        }
    }
}

//public RoomType RoomType { get; set; }
//public ushort PricePerNight { get; set; }