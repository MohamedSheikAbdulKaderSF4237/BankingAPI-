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
           public double ViewBalance(int accountNumber);
           public AccountHolderDetails AddAccountHolder(string name, double balance);
           public AccountHolderDetails Deposit(int accountNumber, double amount);
           public AccountHolderDetails Withdraw(int accountNumber, double amount);
           public AccountHolderDetails TransferMoney(int fromAccountNumber, int toAccountNumber, double amount);
           public AccountHolderDetails DeleteAccount(int accountNumber);

    }
}

