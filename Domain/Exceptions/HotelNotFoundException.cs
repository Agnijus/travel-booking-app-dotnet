﻿
using travel_app.Core.Exceptions;

namespace Domain.Exceptions
{
    public sealed class HotelNotFoundException : NotFoundException
    {

        public HotelNotFoundException(int id)
            : base($"The hotel with the identifier {id} was not found.")
        {
        }

    }
}
