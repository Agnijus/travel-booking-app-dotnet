using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Entities
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BookingId { get; set; }
        public double TotalPrice { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
