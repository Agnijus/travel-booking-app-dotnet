using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository_Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetByIdAsync(int Id);

        void Insert(Transaction transaction);
        void Remove(Transaction transaction);
    }
}
