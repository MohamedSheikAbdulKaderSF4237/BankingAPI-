namespace BankingAPI.Controllers
{
    public class BankingOperations : IBankingOperations
    {
        public AccountHolderDetails ViewAllaccounts()
        {
            for (int i = 0; i < BankingController.accountHolderslist.Count; i++)
            {
                /*Console.WriteLine($"Account Number: " + MainMenu.accountHolderslist[i].accountNumber);
                Console.WriteLine($"Account Holder Name: " + MainMenu.accountHolderslist[i].accountHolderName);
                Console.WriteLine($"Account Balance:" + MainMenu.accountHolderslist[i].accountBalance);
                Console.WriteLine("--------------------------------------------------");*/
              
                return BankingController.accountHolderslist[i];

            }
            return null;
        }

    }
}
