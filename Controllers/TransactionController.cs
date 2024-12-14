using Microsoft.AspNetCore.Mvc;
using OnlineBankApplication.Dto;
using OnlineBankApplication.Interfaces;
using OnlineBankApplication.Models;

namespace OnlineBankApplication.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly ITransactionService _transactionService;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionsRepository transactionsRepository, ITransactionService transactionService, IAccountRepository accountRepository, ILogger<TransactionController> logger)
        {
            _transactionsRepository = transactionsRepository;
            _transactionService = transactionService;
            _accountRepository = accountRepository;
            _logger = logger;
        }
        public IActionResult Transactions()
        {
            try
            {
                IEnumerable<Transaction> transactions = _transactionsRepository.GetTransactions();
                IEnumerable<TransactionDto> transactionDtos = transactions
                    .Select(x => new TransactionDto
                    {
                        TransactionId = x.TransactionId,
                        ToAccountName = x.ToAccountName,
                        FromAccountName = x.FromAccountName,
                        FromAccountBal = x.FromAccountBal,
                        ToAccountBal = x.ToAccountBal,
                        TransactionDate = x.TransactionDate,
                        Amount = x.Amount
                    });

                return View(transactionDtos);
            }
            catch (Exception ex)
            {
                return View("error");
            }
        }

        public IActionResult TransactionDetails(int transactionId)
        {
            try
            {
                Transaction transaction = _transactionsRepository.GetTransaction(transactionId);
                TransactionDto transactionDto = new TransactionDto
                {
                    TransactionId = transaction.TransactionId,
                    ToAccountName = transaction.ToAccountName,
                    FromAccountName = transaction.FromAccountName,
                    FromAccountBal = transaction.FromAccountBal,
                    ToAccountBal = transaction.ToAccountBal,
                    TransactionDate = transaction.TransactionDate,
                    Amount = transaction.Amount
                };
                return View(transactionDto);
            }
            catch (Exception ex)
            {
                return View("error");
            }
        }
        public IActionResult Transfer()
        {
            try
            {
                IEnumerable<Account> accounts = _accountRepository.GetAccounts();
                ViewBag.accounts = accounts;
                return View();
            }
            catch (Exception ex)
            {
                return View("error");
            }
        }
        public IActionResult TransferFunds(string fromAcctName, string toAcctName, Decimal amount)
        {
            try
            {
                Transaction transaction = _transactionService.MakeTransaction(fromAcctName, toAcctName, amount);
                if (transaction == null)
                {
                    _logger.LogError("An error occured while making the transaction");
                    return View("Error");
                }
                _transactionsRepository.AddTransaction(transaction);
                return RedirectToAction("Transactions");
            }
            catch
            {
                return View("error");
            }
        }
    }
}
