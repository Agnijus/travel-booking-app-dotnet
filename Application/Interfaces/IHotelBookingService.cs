﻿using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHotelBookingService
    {
        Booking GetByIdAsync(int id);
        void DeleteByIdAsync(int id);

        Booking CreateAsync(PostBookingRequest request);

    }
}