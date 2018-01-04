using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02BankAccounts
{
    public class Customer
    {
        private string name;
        private string address;
        private CustomerType customerType;

        public Customer(string name, string address, CustomerType customerType)
        {
            this.Name = name;
            this.Address = address;
            this.CustomerType = customerType;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public string Address
        {
            get { return this.address; }
            private set { this.address = value; }
        }

        public CustomerType CustomerType { get; protected set; }

    }
}
