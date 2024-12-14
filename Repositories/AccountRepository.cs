using OnlineBankApplication.Data;
using OnlineBankApplication.Interfaces;
using OnlineBankApplication.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineBankApplication.Controllers;


namespace OnlineBankApplication.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(ApplicationDbContext dbContext, ILogger<AccountRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public bool AddAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            return Save();
        }

        public Account GetAccount(string AccountName)
        {
           Account account = _dbContext.Accounts.FirstOrDefault(x => x.AccountName == AccountName);
           return account;
        }

        public IEnumerable<Account> GetAccounts()
        {
            IEnumerable<Account> accounts = _dbContext.Accounts.ToList();
            return accounts;
        }

        public bool RemoveAccount(string AccountName)
        {
            Account accountToDelete = _dbContext.Accounts.FirstOrDefault(y => y.AccountName == AccountName);
            if (accountToDelete == null)
            {
                _logger.LogError("Account does not exists");
                return false;
            }
            _dbContext.Accounts.Remove(accountToDelete);
            return Save();
        }

        public bool UpdateAccount(Account account)
        {
            _dbContext.Accounts.Update(account);

            return Save();
        }

        public bool Exists(string AccountName)
        {
            return _dbContext.Accounts.Any(x => x.AccountName == AccountName);
        }


        public bool Save()
        {
            try
            {
                int saved = _dbContext.SaveChanges();
                return saved > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while saving the changes to database" + ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateBalance(string accountName, Decimal balance)
        {
            Account account = _dbContext.Accounts.FirstOrDefault(x => x.AccountName == accountName);
            Account account1 = new Account
            {
                AccountName = accountName,
                Balance = balance
            };
             return UpdateAccount(account1);
        }
    }
}
