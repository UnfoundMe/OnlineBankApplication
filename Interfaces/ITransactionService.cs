using OnlineBankApplication.Models;

namespace OnlineBankApplication.Interfaces
{
    public interface ITransactionService
    {
        Transaction MakeTransaction(string fromAcctName, string toAcctName, Decimal amount);
    }
}
