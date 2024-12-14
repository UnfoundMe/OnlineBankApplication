using Microsoft.AspNetCore.Mvc;
using OnlineBankApplication.Interfaces;
using OnlineBankApplication.Models;

namespace OnlineBankApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAccountRepository accountRepository, ILogger<AccountController> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccountList()
        {
            IEnumerable<Account> accounts = _accountRepository.GetAccounts();
            return View(accounts);
        }

        public IActionResult Account([FromQuery] string accountName)
        {
            if(!_accountRepository.Exists(accountName))
            {
                _logger.LogWarning("Account does not exists");                
                return View("Error");
            }
            Account account = _accountRepository.GetAccount(accountName);
            return View(account);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Account Data is invalid");
                return View("Error" );
            }
            if(!_accountRepository.AddAccount(account))
            {
                _logger.LogError("An error occured while saving the changes");
                return View("Error");
            };
            return RedirectToAction("AccountList");
        }
        public IActionResult Edit1([FromQuery] string accountName)
        {
            if (!_accountRepository.Exists(accountName))
            {
                _logger.LogError("Account does not exists");
                return View("Error");
            }
            Account account = _accountRepository.GetAccount(accountName);
            return View(account);
        }
        public IActionResult Edit(Account account)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Account data");
                return View("Error");
            }
            if(!_accountRepository.UpdateAccount(account))
            {
                _logger.LogError("An error occured while saving the changes");
                return View("Error");
            };
            return RedirectToAction("AccountList");
        }

        public IActionResult Delete(string accountName)
        {
            if(!_accountRepository.Exists(accountName))
            {
                _logger.LogWarning("Account does not exists");
                return NotFound();
            }
            if( !_accountRepository.RemoveAccount(accountName) )
            {
                _logger.LogError("An error occured");
                return View("Error");
            };
            return RedirectToAction("AccountList");
        }
    }
}
