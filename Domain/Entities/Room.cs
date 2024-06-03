using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room
    {

        public int Id { get; set; }

        public RoomType RoomType { get; set; }
        public ushort PricePerNight { get; set; }

        public Room(int id, RoomType roomType, ushort pricePerNight)
        {
            Id = id;
            RoomType = roomType;
            PricePerNight = pricePerNight;
        }
    }
}
