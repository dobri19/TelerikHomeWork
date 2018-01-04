using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02BankAccounts
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalcInterestAmount(int months)
        {
            if (this.Customer.CustomerType == CustomerType.Company)
                return base.CalcInterestAmount(months - 2);

            if (this.Customer.CustomerType == CustomerType.Individual)
                return base.CalcInterestAmount(months - 3);

            return base.CalcInterestAmount(months);
        }
    }
}
