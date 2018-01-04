using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02BankAccounts
{
    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public DepositAccount Deposit(decimal money)
        {
            this.Balance += money;
            return this;
        }

        public DepositAccount WithDraw(decimal money)
        {
            if (this.Balance < money)
            {
                throw new ArgumentException("Insufficient amount in the account!");
            }
            this.Balance -= money;
            return this;
        }

        public override decimal CalcInterestAmount(int numberOfMonths)
        {
            if (this.Balance <= 1000)
                return 0;

            return base.CalcInterestAmount(numberOfMonths);
        }
    }
}
