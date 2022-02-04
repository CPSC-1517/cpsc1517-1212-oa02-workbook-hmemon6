using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_cpsc1517
{
    internal class Bank
    {
        //class level method uses static always and can be accessed from anywhere
        public static void Transfer(BankAccount fromAccount, BankAccount toAccount, double amount)
        {
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }
}
