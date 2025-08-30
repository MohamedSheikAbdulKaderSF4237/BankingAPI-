namespace BankingAPI.Controllers
{
    public class BankingOperations : IBankingOperations
    {

        //Dependency Injection of AccountHolderDetails class
        private AccountHolderDetails _accountHolderDetails;
        public BankingOperations(AccountHolderDetails accountHolderDetails)
        {
            _accountHolderDetails = accountHolderDetails;
            if (!AccountHolderDetails.accountHolderslist.Any())
                _accountHolderDetails.AddAccountHolders();
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

    }
}
