using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_cpsc1517
{
    internal class BankAccount
    {
        #region Fields (always private)
        private int _AccountNumber;
        private double _Balance;
        #endregion

        #region modifying fields (properties)

        public int AccountNumber
        {
            get { return _AccountNumber; }
            private set { _AccountNumber = value; }
        }
        public double Balance 
        { 
            get { return _Balance; } 
            set { _Balance = value; }
        }
        #endregion

        public BankAccount(int accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
        public void Deposit(double amount)
        {
            Balance = Balance + amount;
        }
        public void Withdraw(double amount)
        {
            Balance = Balance - amount;
        }

        public override string ToString()
        {
            string accountInfo = "Balance (for account # "
                               + AccountNumber.ToString()
                               + "): "
                               + string.Format("{0:C}", Balance);
            return accountInfo;
        }
    }
}
