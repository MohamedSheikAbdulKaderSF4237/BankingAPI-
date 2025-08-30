using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankingAPI
{
        public class AccountHolderDetails
        {
        public int accountNumber { get; set; }
        public string accountHolderName { get; set; }
        public double accountBalance { get; set; }

        public static List<AccountHolderDetails> accountHolderslist = new List<AccountHolderDetails>();

        public AccountHolderDetails(int accountNumber, string accountHolderName, double accountBalance)
            {
                this.accountNumber = accountNumber;
                this.accountHolderName = accountHolderName;
                this.accountBalance = accountBalance;
            }
        public AccountHolderDetails()
        {

        }

        public void AddAccountHolders()
        {
            accountHolderslist.Add(new AccountHolderDetails(1001, "Alice", 5000));
            accountHolderslist.Add(new AccountHolderDetails(1002, "Bob", 3000));
            accountHolderslist.Add(new AccountHolderDetails(1003, "Charlie", 7000));
        }


    }
}
