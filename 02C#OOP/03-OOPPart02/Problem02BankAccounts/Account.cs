using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02BankAccounts
{
    public abstract class Account
    {
        //customer, balance and interest rate(monthly based).
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        //calculate their interest amount for a given period(in months)
        public virtual decimal CalcInterestAmount(int months)
        {
            decimal result = 0;
            result = months * this.interestRate;
            return result;
        }

        public Customer Customer { get; private set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance cannot be less than zero!");
                }

                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate cannot be less than zero!");
                }

                this.interestRate = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Customer: " + this.Customer.Name);
            sb.AppendLine("Balance: " + this.Balance);
            sb.Append("Interest rate: " + this.InterestRate);
            return sb.ToString();
        }
    }
}
