﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository_Interfaces
{
    public interface IBookingRepository
    {
        Booking GetByIdAsync(int Id);

        void Add(Booking booking);
        void Delete(Booking booking);
    }
}