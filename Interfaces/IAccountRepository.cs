using OnlineBankApplication.Models;

namespace OnlineBankApplication.Interfaces
{
    public interface IAccountRepository
    {
        public IEnumerable<Account> GetAccounts();

        public Account GetAccount(string AccountName);

        public bool AddAccount(Account account);

        public bool RemoveAccount(string AccountName);

        public bool UpdateAccount(Account account);

        public bool Exists(string AccountName);
        public bool Save();

    }
}
