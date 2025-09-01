using System.Diagnostics.Eventing.Reader;

namespace BankingAPI.Controllers
{
    public class BankingOperations : IBankingOperations
    {

        //Dependency Injection of AccountHolderDetails class
        private readonly IAccountHolderDetails _accountHolderDetails;
        public BankingOperations(IAccountHolderDetails accountHolderDetails)
        {
            _accountHolderDetails = accountHolderDetails;

            if (!AccountHolderDetails.accountHolderslist.Any())
            {

                _accountHolderDetails.AddAccountHolders();
            }
        }

        public List<AccountHolderDetails> ViewAllaccounts()
        {
            //for (int i = 0; i < BankingController.accountHolderslist.Count; i++)
            //{
            /*Console.WriteLine($"Account Number: " + MainMenu.accountHolderslist[i].accountNumber);
            Console.WriteLine($"Account Holder Name: " + MainMenu.accountHolderslist[i].accountHolderName);
            Console.WriteLine($"Account Balance:" + MainMenu.accountHolderslist[i].accountBalance);
            Console.WriteLine("--------------------------------------------------");*/

            return AccountHolderDetails.accountHolderslist;

            //}
            // return null;
        }

        public double ViewBalance(int _accountNumber)
        {
            foreach (var account in AccountHolderDetails.accountHolderslist)
            {
                if (account.AccountNumber == _accountNumber)
                {
                    return account.accountBalance;
                }
            }
            return -1;

        }

        public AccountHolderDetails AddAccountHolder(string name, double balance)
        {
           // AccountHolderDetails newAccount = new AccountHolderDetails(name, balance);
            AccountHolderDetails.accountHolderslist.Add(new AccountHolderDetails { accountHolderName=name,accountBalance=balance});
           // AccountHolderDetails.accountHolderslist.Add(new AccountHolderDetails(name, balance));
            foreach (var account in AccountHolderDetails.accountHolderslist)
            {
                if (account.accountHolderName == name && account.accountBalance == balance)
                {
                    return account;
                }
            }
            return null;
        }
        public AccountHolderDetails Deposit(int accountNumber, double amount)
        {
            foreach (var account in AccountHolderDetails.accountHolderslist)
            {
                if (account.AccountNumber == accountNumber)
                {
                    account.accountBalance += amount;
                    return account;
                }
            }
            return null;
        }
        public AccountHolderDetails Withdraw(int accountNumber, double amount)
        {
            foreach (var account in AccountHolderDetails.accountHolderslist)
            {
                if (account.AccountNumber == accountNumber)
                {
                    if (account.accountBalance >= amount)
                    {
                        account.accountBalance -= amount;
                        return account;
                    }
                    else
                    {
                        return null; // Insufficient funds
                    }
                }
            }
            return null; // Account not found
        }
        public AccountHolderDetails TransferMoney(int fromAccountNumber, int toAccountNumber, double amount)
        {
            AccountHolderDetails fromAccount = null;
            AccountHolderDetails toAccount = null;
            foreach (var account in AccountHolderDetails.accountHolderslist)
            {
                if (account.AccountNumber == fromAccountNumber)
                {
                    fromAccount = account;
                }
                else if (account.AccountNumber == toAccountNumber)
                {
                    toAccount = account;
                }
            }
            if (fromAccount != null && toAccount != null && fromAccount.accountBalance >= amount)
            {
                fromAccount.accountBalance -= amount;
                toAccount.accountBalance += amount;
                return fromAccount; // Return the updated from account
            }
 
            if (fromAccount.accountBalance < amount)
            {
                fromAccount.accountBalance = -1; // Indicate insufficient funds
                return fromAccount;
            }
            return null;
            // Transfer failed
        }
        public AccountHolderDetails DeleteAccount(int accountNumber)
        {             
            for (int i = 0; i < AccountHolderDetails.accountHolderslist.Count; i++)
            {
                if (AccountHolderDetails.accountHolderslist[i].AccountNumber == accountNumber)
                {
                    var deletedAccount = AccountHolderDetails.accountHolderslist[i];
                    AccountHolderDetails.accountHolderslist.RemoveAt(i);
                    return deletedAccount;
                }
            }
            return null; // Account not found
        }
    }
}
