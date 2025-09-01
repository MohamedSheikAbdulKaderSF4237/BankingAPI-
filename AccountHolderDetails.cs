using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankingAPI
{
        public class AccountHolderDetails: IAccountHolderDetails
        {

        public static List<AccountHolderDetails> accountHolderslist = new List<AccountHolderDetails>();

        private static int accountNumberValue = 1000;
        private int _accountNumber;
        
        public int AccountNumber
        {
            get {
                return _accountNumber;
            }
            private set { _accountNumber=value; }
        }
             
        
        public string accountHolderName { get; set; }
        public double accountBalance { get; set; }

        public AccountHolderDetails()
          {
            AccountNumber=++accountNumberValue;
            //accountNumber++;
            //AccountNumber = accountNumber;     
            // this.accountHolderName = accountHolderName;
            //this.accountBalance = accountBalance;
        }
       /* public AccountHolderDetails(String name, double balance){
            accountNumber++;
            AccountNumber = accountNumber;
            this.accountHolderName = name;  
            this.accountBalance = balance;

          }*/
        public void AddAccountHolders()
        {
           // accountNumber++;
            accountHolderslist.Add(new AccountHolderDetails {accountHolderName="Alice", accountBalance=5000});
            //accountHolderslist.Add(new AccountHolderDetails("Alice", 5000));
            //accountHolderslist.Add(new AccountHolderDetails("Bob", 3000));
            //accountHolderslist.Add(new AccountHolderDetails("Charlie", 7000));
            accountHolderslist.Add(new AccountHolderDetails { accountHolderName = "Bob", accountBalance = 3000 });
            accountHolderslist.Add(new AccountHolderDetails { accountHolderName = "Charlie", accountBalance = 7000 });
       
        }


    }
}
