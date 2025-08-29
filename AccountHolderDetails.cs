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

        public AccountHolderDetails(int accountNumber, string accountHolderName, double accountBalance)
            {
                this.accountNumber = accountNumber;
                this.accountHolderName = accountHolderName;
                this.accountBalance = accountBalance;
            }

        }
    }
