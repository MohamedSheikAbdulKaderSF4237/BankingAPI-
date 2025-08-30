using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAPI.Controllers
{
    public interface IBankingOperations
        {
           public  List<AccountHolderDetails> ViewAllaccounts();
           // void ViewBalance(int accountNumber);
            //void TransferMoney(int fromAccount, int toAccount, double amount);
        }
}

