using OnlineBankApplication.Models;

namespace OnlineBankApplication.Interfaces
{
    public interface ITransactionsRepository
    {
        IEnumerable<Transaction> GetTransactions();

        Transaction GetTransaction(int transactionId); 

        bool HasTransactions(int transactionId);
        bool AddTransaction(Transaction transaction);
    }
}
