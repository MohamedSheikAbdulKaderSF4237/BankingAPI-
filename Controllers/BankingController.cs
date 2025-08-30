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
            //if (!accountHolderslist.Any())
              //  AddAccountHolders();
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
