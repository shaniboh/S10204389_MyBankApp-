using System;
using System.Collections.Generic;
using System.Text;

namespace S10204389_MyBankApp_
{
    class SavingsAccount: BankAccount
    {
        public double Rate { get; set; }
        
        public SavingsAccount() : base() { }

        public SavingsAccount(string accNo, string accName, double bal, double r) : base(accNo, accName, bal)
        {
            Rate = r;
        }

        public double CalculateInterest( )
        {
            return Balance * (Rate / 100);
        }

        public override string ToString()
        {
            return base.ToString() + "\tRate:" + Rate;
        }

    }
}
