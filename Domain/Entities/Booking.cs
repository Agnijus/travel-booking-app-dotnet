using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ReservationId { get; set; }
        public double TotalPrice { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
