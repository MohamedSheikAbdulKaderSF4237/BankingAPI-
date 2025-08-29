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
        private readonly IBankingOperations _bankingOperations;

        public static List<AccountHolderDetails> accountHolderslist = new List<AccountHolderDetails>();

        public BankingController(IBankingOperations bankingOperations)
        {
            _bankingOperations = bankingOperations;
            if (!accountHolderslist.Any())
                AddAccountHolders();
        }

        public void AddAccountHolders()
        {
            accountHolderslist.Add(new AccountHolderDetails(1001, "Alice", 5000));
            accountHolderslist.Add(new AccountHolderDetails(1002, "Bob", 3000));
            accountHolderslist.Add(new AccountHolderDetails(1003, "Charlie", 7000));
        }

        [HttpGet("ViewAllAccountDetails")]
       // [Route("ViewAllAccountDetails")]

        //[FromBody] AccountHolderDetails accountHolderDetails
        public ActionResult ViewAllaccountDetails()
            {
               // AddAccountHolders();
                return Ok( _bankingOperations.ViewAllaccounts() );
            }

    }
}
