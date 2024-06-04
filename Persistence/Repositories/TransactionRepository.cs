using Domain.Entities;
using Domain.Repository_Interfaces;
using Persistence.Data;


namespace Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<Transaction> GetByIdAsync(int Id)
        {
            var transactions = TransactionData.Transactions.FirstOrDefault(t => t.Id == Id);
            return Task.FromResult(transactions);
        }

        public void Insert(Transaction transaction)
        {
            TransactionData.Transactions.Add(transaction);
        }

        public void Remove(Transaction transaction)
        {
            TransactionData.Transactions.Remove(transaction);
        }
    }
}
