using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Enums;

namespace Contracts.DTOs
{
    public class RoomDto
    {

        public int Id { get; set; }

        public RoomType RoomType { get; set; }
        public ushort PricePerNight { get; set; }

       

    }
}
