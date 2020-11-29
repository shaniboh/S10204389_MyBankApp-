using System;
using System.Collections.Generic;
using System.Text;

namespace S10204389_MyBankApp_
{
    class BankAccount
    {
        public string AccNo { get; set; }
        public string AccName { get; set; }
        public double Balance { get; set; }

        public BankAccount() { }
        public BankAccount(string accNo, string accName, double bal)
        {
            AccNo = accNo;
            AccName = accName;
            Balance = bal;
        }

        public void Deposit(double amt)
        {
            Balance += amt;
        }

        public bool Withdraw(double amt)
        {
            if (Balance >= amt)
            {
                Balance -= amt;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Account Number:" + AccNo + "\tAccount Name:" + AccName + "\tBalance:" + Balance;

        }
    }
}
