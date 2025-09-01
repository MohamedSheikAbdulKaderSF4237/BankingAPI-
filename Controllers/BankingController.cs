using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace BankingAPI.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    [Route("api/[controller]")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class BankingController : ControllerBase
    {

        //Dependency Injection of IBankingOperations interface
        private readonly IBankingOperations _bankingOperations;

        public BankingController(IBankingOperations bankingOperations)
        {
            _bankingOperations = bankingOperations;
        }


        [HttpGet("ViewAllAccountDetails")]
        // [Route("ViewAllAccountDetails")]

        //[FromBody] AccountHolderDetails accountHolderDetails
        public ActionResult ViewAllaccountDetails()
        {
            // AddAccountHolders();
            return Ok(_bankingOperations.ViewAllaccounts());
        }

        [HttpGet("ViewBalance")]
        public ActionResult ViewBalance(int accountNumber)
        {
            var accountBalance = _bankingOperations.ViewBalance(accountNumber);
            if (accountBalance != -1)
            {
                return Ok(accountBalance);
            }
            else
            {
                return NotFound(new { message = "Account Number not found" });
            }
        }

        [HttpPost("add")]
        public ActionResult AddAccountHolder([FromBody] string name, double balance)
        {
            var account = _bankingOperations.AddAccountHolder(name, balance);
            return Ok(account);
        }


        [HttpPut("deposit")]
        public ActionResult Deposit(int accountNumber, double amount)
        {
            var account = _bankingOperations.Deposit(accountNumber, amount);
            if (account == null)
            {
                return NotFound(new { message = "Account Number not found" });
            }
            else
            {
                return Ok(account);
            }

        }
        [HttpPut("withdraw")]
        public ActionResult Withdraw(int accountNumber, double amount)
        {
            var account = _bankingOperations.Withdraw(accountNumber, amount);
            if (account == null)
            {
                return NotFound(new { message = "Account Number not found" });
            }
            else
            {
                if (account.accountBalance == -1)
                {
                    return BadRequest(new { message = "Insufficient Balance" });
                }
                return Ok(account);
            }
        }
        [HttpPost("transfer")]
        public ActionResult TransferMoney(int fromAccount, int toAccount, double amount)
        {
            var account = _bankingOperations.TransferMoney(fromAccount, toAccount, amount);
            if (account == null)
            {
                return NotFound(new { message = "Either from_Account Number or to_Account Number not found" });
            }
            else if (account.accountBalance == -1)
            {
                return BadRequest(new { message = "Insufficient Balance" });
            }
            return Ok(account);
        }

        [HttpDelete("delete")]
        public ActionResult DeleteAccount(int accountNumber)
        {
            var account = _bankingOperations.DeleteAccount(accountNumber);
            if (account == null)
            {
                return NotFound(new { message = "Account Number not found" });
            }
            return Ok(account);
        }
    }
}
