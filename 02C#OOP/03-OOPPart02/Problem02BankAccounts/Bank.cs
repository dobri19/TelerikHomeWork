using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02BankAccounts
{
    public class Bank
    {
        private readonly List<Account> accounts = new List<Account>();

        public Bank(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public Bank AddAccount(Account account)
        {
            this.accounts.Add(account);
            return this;
        }

        public Bank RemoveAccount(Account account)
        {
            this.accounts.Remove(account);
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bank: {this.Name}");

            foreach (Account account in this.accounts)
            {
                sb.AppendLine(account.ToString());
            }

            return sb.ToString();
        }
    }
}
