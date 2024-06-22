﻿using Application.Models.Requests;
using Application.Models.Responses;
using travel_app.Core.Entities;

namespace Application.Interfaces
{
    public interface IHotelService
    {
        //Task<List<Hotel>> GetAllAsync();
        Task<GetHotelResponse> GetByIdAsync(int id);
        //Task<List<Hotel>> GetByDestinationAsync(string destination);
        Task<Hotel> CreateAsync(PostHotelRequest request);
        Task DeleteByIdAsync(int id);
    }
}
