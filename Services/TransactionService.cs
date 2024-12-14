using OnlineBankApplication.Interfaces;
using OnlineBankApplication.Models;

namespace OnlineBankApplication.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountRepository _accountRepository;
        public TransactionService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;                
        }

        public Transaction MakeTransaction(string fromAcctName, string toAcctName, Decimal amount)
        {
            Account payAccount = _accountRepository.GetAccount(fromAcctName);
            Account recepientAccount = _accountRepository.GetAccount(toAcctName);

            try
            {
               if (payAccount.Balance < amount)
                {
                    Console.WriteLine("Insufficient funds to make a transaction");
                    return null;
                }
                payAccount.Balance = payAccount.Balance - amount;
                recepientAccount.Balance = recepientAccount.Balance + amount;
                _accountRepository.UpdateAccount(payAccount);
                _accountRepository.UpdateAccount(recepientAccount);              

            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return null;
            }
            Transaction transaction = new Transaction
            {
                // TransactionId = transaction.TransactionId,
                FromAccountName = fromAcctName,
                ToAccountName = toAcctName,
                Amount = amount,
                FromAccountBal = (decimal)payAccount.Balance,
                ToAccountBal = (decimal)recepientAccount.Balance,
                TransactionDate = DateTime.Now
            };
            return transaction;
        }
    }
}
