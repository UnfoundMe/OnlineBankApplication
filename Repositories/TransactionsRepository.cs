using Microsoft.AspNetCore.Http.HttpResults;
using OnlineBankApplication.Controllers;
using OnlineBankApplication.Data;
using OnlineBankApplication.Interfaces;
using OnlineBankApplication.Models;

namespace OnlineBankApplication.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<TransactionsRepository> _logger;
        public TransactionsRepository(ApplicationDbContext dbContext, ILogger<TransactionsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public Transaction GetTransaction(int transactionId)
        {
            Transaction transaction = _dbContext.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);
            return transaction;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            IEnumerable<Transaction> transactions = _dbContext.Transactions.ToList();
            if (!transactions.Any())
            {
                _logger.LogError("Oops! No transactions to display"); 
                return null;
            }
            return transactions;

        }

        public bool AddTransaction(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            return Save();
        }

        public bool Save()
        {
            int saved = _dbContext.SaveChanges();
            return saved > 0;
        }
        public bool HasTransactions(int transactionId)
        {
            Transaction transaction = _dbContext.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);
            if(transaction == null)
            {
                _logger.LogError("No transaction found with the given TransactionId");
                return false;
            }
            return true;
        }
    }
}
