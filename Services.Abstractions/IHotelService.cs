﻿using Contracts.DTOs;
using Domain.Entities;
using travel_booking_app_dotnet.Core.Entities;

namespace Services.Abstractions
{
    public interface IHotelService
    {
        List<Hotel> GetAllAsync();
        Hotel GetByIdAsync(int id);
        List<Hotel> GetByDestinationAsync(string destination);
        Hotel CreateAsync(PostHotelRequest request);
        void DeleteAsync(HotelDto hotelDto);

    }
}